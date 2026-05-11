namespace HangOutPA.Models;

public class GroupEvent
{
    public string Title { get; set; }
    public string LastMessage { get; set; }
    public string ImageSource { get; set; }
    public double TargetBudget { get; set; }
    public double CurrentBudget { get; set; }
    public string Status { get; set; } // "Active", "Funding", "Completed"
    public double Progress => CurrentBudget / TargetBudget; // Для прогресс-бара
}
