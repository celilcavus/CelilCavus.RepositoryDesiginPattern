using CelilCavus.RepositoryDesiginPattern.Data.Context;
using CelilCavus.RepositoryDesiginPattern.Data.Entites;
using CelilCavus.RepositoryDesiginPattern.Data.Interfaces;
using CelilCavus.RepositoryDesiginPattern.Data.Repository;
using CelilCavus.RepositoryDesiginPattern.Data.UnitOfWork;
using CelilCavus.RepositoryDesiginPattern.Mapping;
using CelilCavus.RepositoryDesiginPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace CelilCavus.RepositoryDesiginPattern.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _work;
        private readonly IUserMapper _mapper;

        public HomeController(IUnitOfWork work, IUserMapper mapper)
        {
            _work = work;
            _mapper = mapper;
        }

        public IActionResult Index()
        {

            return View(_mapper.MapToListOfUserList(_work.GetRepository<ApplicationUser>().GetAll()));
        }
    }
}
