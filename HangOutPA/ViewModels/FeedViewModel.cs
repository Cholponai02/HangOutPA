using CommunityToolkit.Maui.Views;
using HangOutPA.Models;
using HangOutPA.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;
using HangOutPA.Views;

namespace HangOutPA.ViewModels;

public class FeedViewModel : BindableObject // Базовый класс для обновлений UI
{
    private readonly IEventService _eventService;
    private List<Event> _allEvents = new();

    public ObservableCollection<Event> FilteredEvents { get; } = new();

    // Команда для фильтрации
    public ICommand FilterCommand { get; }
    public ICommand OpenCommentsCommand { get; }

    public FeedViewModel()
    {
        _eventService = new MockEventService();
        FilterCommand = new Command<string>(ExecuteFilterCommand);
        OpenCommentsCommand = new Command<Event>(OnOpenComments);
        // Загружаем данные при создании
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        var events = await _eventService.GetEventsAsync();
        _allEvents = events;
        ExecuteFilterCommand("All"); // По умолчанию показываем всё
    }

    private void ExecuteFilterCommand(string category)
    {
        FilteredEvents.Clear();

        var results = category == "All"
            ? _allEvents
            : _allEvents.Where(e => e.Category == category).ToList();

        foreach (var ev in results)
            FilteredEvents.Add(ev);
    }

    private async void OnOpenComments(Event selectedEvent)
    {
        if (selectedEvent == null) return;

        // Создаем попап и передаем в него список комментариев выбранного события
        var popup = new CommentsPopup(selectedEvent.Comments);
        await Application.Current.MainPage.ShowPopupAsync(popup);
    }
}