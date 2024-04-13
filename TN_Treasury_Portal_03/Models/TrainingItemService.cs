// This allows interaction with TrainingItem objects in the database
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
namespace TN_Treasury_Portal_03.Models
{
    public class TrainingItemService
    {
        private readonly TnTreasuryPortalContext _context;
        public TrainingItemService(TnTreasuryPortalContext context)
        {
            _context = context;
        }
        public async void CreateTrainingItem(string NewTitle, string NewDescription, string NewLink)
        {
            SqlParameter paramTitle = new SqlParameter("@NewTitle", NewTitle);

            SqlParameter paramDescription = new SqlParameter("@NewDescription", NewDescription);

            SqlParameter paramLink = new SqlParameter("@NewLink", NewLink);

            _context.TrainingItems.FromSqlRaw("Execute dbo.CreateTrainingItem @NewTitle,@NewDescription,@NewLink", paramTitle, paramDescription, paramLink);
        }
        public async void UpdateTrainingItem(int TargetId, string NewTitle, string NewDescription, string NewLink)
        {
            SqlParameter paramId = new SqlParameter("@TargetId", TargetId);

            SqlParameter paramTitle = new SqlParameter("@NewTitle", NewTitle);

            SqlParameter paramDescription = new SqlParameter("@NewDescription", NewDescription);

            SqlParameter paramLink = new SqlParameter("@NewLink", NewLink);

            _context.TrainingItems.FromSqlRaw("Execute dbo.EditTrainingItem @TargetId,@NewTitle,@NewDescription,@NewLink", paramId, paramTitle, paramDescription, paramLink);
        }
        public async void DeleteTrainingItem(int TargetId)
        {
            SqlParameter paramId = new SqlParameter("@TargetId", TargetId);

            _context.TrainingItems.FromSqlRaw("Execute dbo.DeleteTrainingItem @TargetId", paramId);
        }
    }
}
