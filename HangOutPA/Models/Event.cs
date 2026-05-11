namespace HangOutPA.Models
{
    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public string TimeLocation { get; set; }

        public List<Comment> Comments { get; set; } = new();
    }
}
