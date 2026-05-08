using HangOutPA.Models;
namespace HangOutPA.Services;

public interface IEventService
{
    Task<List<Event>> GetEventsAsync();
}

public class MockEventService : IEventService
{
    public async Task<List<Event>> GetEventsAsync()
    {
        // Имитируем небольшую задержку сети
        await Task.Delay(100);

        return new List<Event>
        {
            new Event {
                Category="Sport",
                ImageSource="football_scroll.jpg",
                Description="Football match. 5 slots left.",
                TimeLocation="Today 4PM • Trastevere"
            },
            new Event {
                Category="Sport",
                ImageSource="running_scroll.jpg",
                Description="Running. Need 5 runnners.",
                TimeLocation="Today 6PM • Parioli"
            },
            new Event {
                Category="Study",
                ImageSource="library_scroll.jpg",
                Description="Exam preparation: Roman History.",
                TimeLocation="Tomorrow 2PM • Sapienza"
            }
        };
    }
}
