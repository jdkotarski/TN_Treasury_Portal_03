using System.ComponentModel.DataAnnotations;

namespace TN_Treasury_Portal_03.Data
{
    public class TrainingItem
    {
        //Components user can add to FAQ object
        [Required]
        public static int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        public string Link { get; set; } = "";
                   

        //Putting all HTML components together to create the TrainingItem element
        public override string ToString()
        {
            Id += 1;
            //Formatting components to be added onto the page
            string TitleHTML = "<h3>" + Title + "</h3><br>";
            string DescriptionHTML = "<p>" + Description + "</p><br>";
            string LinkHTML = "<a href= " + Link + ">View Link Here</a>";
            
            return "<div class=TrainingItem id=TrainingItem" + Id + ">" + TitleHTML + DescriptionHTML + LinkHTML;
        }
    }
}
