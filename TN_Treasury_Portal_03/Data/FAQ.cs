using System.ComponentModel.DataAnnotations;

namespace TN_Treasury_Portal_03.Data
{
    public class FAQ
    {
        //Components user can add to FAQ object
        [Required]
        public static int Id { get; set; }
        [Required]
        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        public string Link { get; set; } = "";
                   

        //Putting all HTML components together to create the FAQ element
        public override string ToString()
        {
            Id += 1;
            //Formatting components to be added onto the page
            string TitleHTML = "<h3>" + Title + "</h3><hr><br>";
            string DescriptionHTML = "<p>" + Description + "</p><br>";
            string LinkHTML = "<a href=&quot; " + Link + "&quot;></a>";
            
            return "<div id=FAQ" + Id + ">" + TitleHTML + DescriptionHTML + LinkHTML;
        }
    }
}
