using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Award
    {
        public int ID { get; set; }

        [MaxLength(50), Required]
        public string Title { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public Award() { }
        public Award(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string[] GetData()
        {
            return new string[] { Title, Description };
        }
    }
}
