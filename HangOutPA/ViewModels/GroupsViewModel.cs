using System.Collections.ObjectModel;
using System.Windows.Input;
using HangOutPA.Models;
using HangOutPA.Views;

namespace HangOutPA.ViewModels;

public class GroupsViewModel : BindableObject
{
    public ObservableCollection<GroupModel> MyGroups { get; set; } = new();
    public ObservableCollection<GroupModel> ActiveGroups => Services.DataService.ActiveGroups;
    public ObservableCollection<GroupModel> PastGroups => Services.DataService.PastGroups;

    public GroupsViewModel()
    {
        if (Services.DataService.PastGroups.Count == 0)
        {
            Services.DataService.PastGroups.Add(new GroupModel
            {
                Name = "Coffee at Sapienza",
                ImageUrl = "coffee.png",
                LastMessage = "It was fun!",
                LastMessageTime = "Yesterday"
            });
        }
        GoToDetailsCommand = new Command<GroupModel>(OnGoToDetails);
        //LoadGroups();
    }

    public ICommand GoToDetailsCommand { get; }

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

    private async void OnGoToDetails(GroupModel selectedGroup)
    {
        if (selectedGroup == null) return;

        // Находим оригинальное событие по имени (или ID), чтобы передать его в детали
        // Для этого можно обратиться к MockEventService или DataService
        var allEvents = await new Services.MockEventService().GetEventsAsync();
        var eventDetails = allEvents.FirstOrDefault(e => e.Title == selectedGroup.Name);

        if (eventDetails != null)
        {
            var navParam = new Dictionary<string, object> { { "SelectedEvent", eventDetails } };
            await Shell.Current.GoToAsync(nameof(EventDetailsPage), navParam);
        }
        if (selectedGroup.Name == "Coffee at Sapienza")
        {
            await Application.Current.MainPage.DisplayAlert("Warning", "This page is under construction.", "OK");
        }
    }
}