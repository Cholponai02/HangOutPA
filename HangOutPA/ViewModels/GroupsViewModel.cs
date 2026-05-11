using System.Collections.ObjectModel;
using HangOutPA.Models;

namespace HangOutPA.ViewModels;

public class GroupsViewModel : BindableObject
{
    public ObservableCollection<GroupModel> MyGroups { get; set; } = new();

    public GroupsViewModel()
    {
        LoadGroups();
    }

    private void LoadGroups()
    {
        // Имитация данных (Mock Data)
        MyGroups.Add(new GroupModel
        {
            Name = "Park Basketball 🏀",
            ImageUrl = "basketball_group.jpg",
            LastMessage = "Sarah: I'll bring the new ball!",
            LastMessageTime = "14:20",
            TargetAmount = 20,
            CurrentAmount = 15
        });

        MyGroups.Add(new GroupModel
        {
            Name = "Pizza Night 🍕",
            ImageUrl = "pizza_group.jpg",
            LastMessage = "Mark: Let's order from Mario's",
            LastMessageTime = "10:05",
            TargetAmount = 50,
            CurrentAmount = 45
        });

        MyGroups.Add(new GroupModel
        {
            Name = "Sapienza Study 📚",
            ImageUrl = "study_group.jpg",
            LastMessage = "You: See you at the library!",
            LastMessageTime = "Yesterday",
            TargetAmount = 0, // Бесплатная встреча
            CurrentAmount = 0
        });
    }
}