namespace Entities
{
    public class Award
    {
        public int ID { get; set; }
        public string Title { get; set; }
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
