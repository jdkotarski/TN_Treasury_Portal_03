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
        // Creates TrainingItem object in database with given user input
        public async Task<TrainingItem[]> CreateTrainingItem(string NewTitle, string NewDescription, string NewLink)
        {
            TrainingItem[] trainingItemObjects;
            SqlParameter paramTitle = new SqlParameter("@NewTitle", NewTitle);
            SqlParameter paramDescription = new SqlParameter("@NewDescription", NewDescription);
            SqlParameter paramLink = new SqlParameter("@NewLink", NewLink);

            // Put in this useless try/catch to avoid "unhandled exception" popup on browser
            try
            {
                trainingItemObjects = _context.TrainingItems.FromSqlRaw("Execute dbo.CreateTrainingItem @NewTitle,@NewDescription,@NewLink", paramTitle, paramDescription, paramLink).ToArray();
            }
            catch (Exception ex) { trainingItemObjects = null; }

            return trainingItemObjects;
        }
        // Retrieves all TrainingItem object titles, descriptions, and links from database
        public async Task<TrainingItem[]> ReadTrainingItem()
        {
            TrainingItem[] TrainingItemObjects;
            TrainingItemObjects = _context.TrainingItems.FromSqlRaw("Execute dbo.ReadTrainingItem").ToArray();
            return TrainingItemObjects;
        }
        // Updates TrainingItem object in database with given user input
        public async void UpdateTrainingItem(int TargetId, string NewTitle, string NewDescription, string NewLink)
        {
            SqlParameter paramId = new SqlParameter("@TargetId", TargetId);

            SqlParameter paramTitle = new SqlParameter("@NewTitle", NewTitle);

            SqlParameter paramDescription = new SqlParameter("@NewDescription", NewDescription);

            SqlParameter paramLink = new SqlParameter("@NewLink", NewLink);

            _context.TrainingItems.FromSqlRaw("Execute dbo.EditTrainingItem @TargetId,@NewTitle,@NewDescription,@NewLink", paramId, paramTitle, paramDescription, paramLink);
        }
        // Deletes specified TrainingItem object from database
        public async Task<TrainingItem[]> DeleteTrainingItem(int? TargetId)
        {
            TrainingItem[] trainingItemObjects;
            SqlParameter paramTargetId = new SqlParameter("@TargetId", TargetId);

            // Put in this useless try/catch to avoid "unhandled exception" popup on browser
            try
            {
                trainingItemObjects = _context.TrainingItems.FromSqlRaw("Execute dbo.DeleteTrainingItem @TargetId", paramTargetId).ToArray();
            }
            catch (Exception ex) { trainingItemObjects = null; }

            return trainingItemObjects;
        }
    }
}
