using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Data.UnitOfWork;
using CelilCavus.RepositoryDesiginPattern.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CelilCavus.RepositoryDesiginPattern.Controllers
{
    public class AccountController : Controller
    {

        // private readonly IRepository<Account> _account;
        // private readonly IRepository<ApplicationUser> _applicationUser;
        // private readonly IUserMapper _mapper;

        // private readonly IAccountMapper _AccountMapper;
        // public AccountController(IRepository<Account> account, IUserMapper mapper, IAccountMapper accountMapper, IRepository<ApplicationUser> applicationUser)
        // {
        //     _mapper = mapper;
        //     _AccountMapper = accountMapper;
        //     _account = account;
        //     _applicationUser = applicationUser;
        // }

        private readonly UnitOfWork _work;

        public AccountController(UnitOfWork work)
        {
            _work = work;
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var UserInfo = _work.GetRepository<ApplicationUser>().GetById(id);
            return View(new UserListModel
            {
                Id = UserInfo.Id,
                Name = UserInfo.Name,
                LastName = UserInfo.LastName
            });

        }
        [HttpPost]
        public IActionResult Create(AccountCreateModel model)
        {
            _work.GetRepository<Account>().Create(new Account
            {
                AccountNumber = model.AccountNumber,
                Balance = model.Balance,
                ApplicationUserId = model.ApplicationUserId
            });
            _work.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult GetByUserId(int id)
        {
            var query = _work.GetRepository<Account>().GetQueryable().Where(x => x.Id == id).ToList();

            var user = _work.GetRepository<ApplicationUser>().GetById(id);

            var list = new List<AccountListModel>();

            ViewBag.FullName = string.Concat(user.Name, " ", user.LastName);

            foreach (var item in query)
            {
                list.Add(new()
                {
                    AccountNumber = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId,
                    Balance = item.Balance,
                    Id = user.Id
                });
            }
            return View(list);

        }
        //Send Money
        [HttpGet]
        public IActionResult SendMoney(int AccountId)
        {
            var query = _work.GetRepository<Account>().GetQueryable().Where(x => x.Id == AccountId).ToList();

            var list = new List<AccountListModel>();

            ViewBag.senderId = AccountId;

            foreach (var item in list)
            {
                list.Add(new()
                {
                    AccountNumber = item.AccountNumber,
                    ApplicationUserId = item.ApplicationUserId,
                    Balance = item.Balance,
                    Id = item.Id,
                });
            }
            return View(new SelectList(list, "Id", "AccountNumber"));
        }

        [HttpPost]
        public IActionResult SendMoney(SendMoneyModel model)
        {
            var senderAccount = _work.GetRepository<Account>().GetById(model.SenderId);
            senderAccount.Balance -= model.Amount;
            _work.GetRepository<Account>().Update(senderAccount);
            var account = _work.GetRepository<Account>().GetById(model.AccountId);
            account.Balance += model.Amount;
            _work.GetRepository<Account>().Update(account);

            _work.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
