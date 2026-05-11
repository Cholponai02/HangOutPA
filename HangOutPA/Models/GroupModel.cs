namespace HangOutPA.Models;

public class GroupModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string LastMessage { get; set; }
    public string LastMessageTime { get; set; }
    public double TargetAmount { get; set; } // Сколько нужно собрать в "Pot"
    public double CurrentAmount { get; set; } // Сколько уже собрано

    // Вычисляемые свойства для UI
    public double Progress => TargetAmount > 0 ? CurrentAmount / TargetAmount : 0;
    public string ProgressText => $"${CurrentAmount} / ${TargetAmount}";
    public bool HasPot => TargetAmount > 0;
}