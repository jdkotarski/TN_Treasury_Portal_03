// This allows interaction with FAQ objects in the database
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace TN_Treasury_Portal_03.Models
{
    public class FaqService
    {
        private readonly TnTreasuryPortalContext _context;
        public FaqService(TnTreasuryPortalContext context)
        {
            _context = context;
        }
        // Creates FAQ object in database with given user input
        public async void CreateFaq(string NewTitle, string NewDescription, string NewLink)
        {
            SqlParameter paramTitle = new SqlParameter("@NewTitle", NewTitle);
            
            SqlParameter paramDescription = new SqlParameter("@NewDescription", NewDescription);

            SqlParameter paramLink = new SqlParameter("@NewLink", NewLink);

            _context.Faqs.FromSqlRaw("Execute dbo.CreateFaq @NewTitle,@NewDescription,@NewLink", paramTitle, paramDescription, paramLink);
        }
        // Retrieves all FAQ object titles, descriptions, and links from database
        public async Task<Faq[]> ReadFaq()
        {
            Faq[] faqObjects;
            faqObjects = _context.Faqs.FromSqlRaw("Execute dbo.ReadFaq").ToArray();
            return faqObjects;
        }
        // Updates FAQ object in database with given user input
        public async void UpdateFaq(int TargetId, string NewTitle, string NewDescription, string NewLink)
        {
            SqlParameter paramId = new SqlParameter("@TargetId", TargetId);

            SqlParameter paramTitle = new SqlParameter("@NewTitle", NewTitle);

            SqlParameter paramDescription = new SqlParameter("@NewDescription", NewDescription);

            SqlParameter paramLink = new SqlParameter("@NewLink", NewLink);

            _context.Faqs.FromSqlRaw("Execute dbo.EditFaq @TargetId,@NewTitle,@NewDescription,@NewLink", paramId, paramTitle, paramDescription, paramLink);
        }
        // Deletes specified FAQ object from database
        public async void DeleteFaq(int TargetId)
        {
            SqlParameter paramId = new SqlParameter("@TargetId", TargetId);

            _context.Faqs.FromSqlRaw("Execute dbo.DeleteFaq @TargetId", paramId);
        }
    }
}
