namespace HangOutPA.Models
{
    public class Event
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string ImageSource { get; set; }
        public string Description { get; set; }
        public string TimeLocation { get; set; }

        public double GoalAmount { get; set; }
        public double CurrentFunded { get; set; }
        public string GoalDescription { get; set; }

        public List<Comment> Comments { get; set; } = new();
        public List<Participant> Participants { get; set; } = new();
    }

    public class Participant
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Action { get; set; } // Например: "joined" или "funded $5"
    }

}
