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
                TimeLocation="Today 4PM • Trastevere",
                Comments = new List<Comment>
            {
                new Comment { UserName="Sarah", Text="I'm coming with 2 friends!", UserAvatar="user1.png" },
                new Comment { UserName="Marco", Text="Do we have a ball?", UserAvatar="user2.png" }
            }
            },
            new Event {
                Category="Sport",
                ImageSource="running_scroll.jpg",
                Description="Running. Need 5 runnners.",
                TimeLocation="Today 6PM • Parioli",
                Comments = new List<Comment>
            {
                new Comment { UserName="Elena", Text="Is it for beginners?", UserAvatar="user3.png" }
            }
            },
            new Event {
                Category="Study",
                ImageSource="library_scroll.jpg",
                Description="Exam preparation: Roman History.",
                TimeLocation="Tomorrow 2PM • Sapienza",
                Comments = new List<Comment>
            {
                new Comment { UserName="Prof. Rossi", Text="I can help with materials.", UserAvatar="user4.png" }
            }
            }
        };
    }
}
