using HangOutPA.Models;
using HangOutPA.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace HangOutPA.ViewModels;

public class FeedViewModel : BindableObject // Базовый класс для обновлений UI
{
    private readonly IEventService _eventService;
    private List<Event> _allEvents = new();

    public ObservableCollection<Event> FilteredEvents { get; } = new();

    // Команда для фильтрации
    public ICommand FilterCommand { get; }

    public FeedViewModel()
    {
        _eventService = new MockEventService();
        FilterCommand = new Command<string>(ExecuteFilterCommand);

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
}