using HangOutPA.Models;
using System.Collections.ObjectModel;

namespace HangOutPA.Services;

public static class DataService
{
    // Текущие активные группы
    public static ObservableCollection<GroupModel> ActiveGroups { get; set; } = new();

    // Прошедшие мероприятия (История)
    public static ObservableCollection<GroupModel> PastGroups { get; set; } = new();

    public static void JoinEvent(Event ev)
    {
        // Проверяем, не добавлена ли уже эта группа
        if (ActiveGroups.Any(g => g.Name == ev.Title)) return;

        ActiveGroups.Add(new GroupModel
        {
            Id = Guid.NewGuid().ToString(),
            Name = ev.Title,
            ImageUrl = ev.ImageSource,
            LastMessage = "You joined the group!",
            LastMessageTime = DateTime.Now.ToString("HH:mm"),
            TargetAmount = ev.GoalAmount,
            CurrentAmount = ev.CurrentFunded
        });
    }

    public static void CompleteEvent(string groupId)
    {
        var group = ActiveGroups.FirstOrDefault(g => g.Id == groupId);
        if (group != null)
        {
            ActiveGroups.Remove(group);

            // Добавляем пометку о завершении (например, для статистики профиля)
            group.LastMessage = "Event Completed";
            group.LastMessageTime = DateTime.Now.ToString("dd MMM");

            PastGroups.Insert(0, group); // Добавляем в начало списка истории
        }
    }

}