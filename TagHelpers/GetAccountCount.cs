using CelilCavus.RepositoryDesiginPattern.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CelilCavus.RepositoryDesiginPattern.TagHelpers
{
    [HtmlTargetElement("GetAccountCount")]
    public class GetAccountCount : TagHelper
    {
        public int ApplicationUserId { get; set; }

        private readonly BankContext _context;
        public GetAccountCount(BankContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var AccountCount = _context.Accounts.Count(x=>x.ApplicationUserId == ApplicationUserId);
            var Html = $@"<span class='badge bg-danger'>{AccountCount}</span>";
            output.Content.SetHtmlContent(Html);
        }
    }
}
