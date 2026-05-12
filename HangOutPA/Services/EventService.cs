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
            // СОБЫТИЕ 1: ФУТБОЛ
            new Event {
                Title = "Football",
                Category = "Sport",
                ImageSource = "football_scroll.jpg",
                Description = "Football match. 5 slots left.",
                TimeLocation = "Today 4PM • Trastevere",
                GoalAmount = 20,
                CurrentFunded = 15,
                GoalDescription = "Court/Ball",
                Participants = new List<Participant> {
                    new Participant { Name = "Sarah", Avatar = "user1.png", Action = "joined" },
                    new Participant { Name = "Mark", Avatar = "user2.png", Action = "funded $5" },
                    new Participant { Name = "Maya", Avatar = "user3.png", Action = "joined" }
                },
                 Comments = new List<Comment>
                {
                    new Comment { UserName="Sarah", Text="I'm coming with 2 friends!", UserAvatar="user1.png" },
                    new Comment { UserName="Marco", Text="Do we have a ball?", UserAvatar="user2.png" }
                }
            },

            // СОБЫТИЕ 2: ИСТОРИЯ (Бесплатно или дешево)
            new Event {
                Title = "Roman History",
                Category = "Study",
                ImageSource = "library_scroll.jpg",
                Description = "Exam preparation.",
                TimeLocation = "Tomorrow 2PM • Sapienza",
                GoalAmount = 5,
                CurrentFunded = 2,
                GoalDescription = "Print materials",
                Participants = new List<Participant> {
                    new Participant { Name = "Prof. Rossi", Avatar = "user4.png", Action = "joined" },
                    new Participant { Name = "Luca", Avatar = "user2.png", Action = "funded $2" }
                },
                Comments = new List<Comment>
                {
                    new Comment { UserName="Prof. Rossi", Text="I can help with materials.", UserAvatar="user4.png" }
                }
            },

            // СОБЫТИЕ 3: БЕГ (Без сбора денег)
            new Event {
                Title = "Running",
                Category = "Sport",
                ImageSource = "running_scroll.jpg",
                Description = "Morning run.",
                TimeLocation = "Today 6PM • Parioli",
                GoalAmount = 0,
                CurrentFunded = 0,
                GoalDescription = "Free event",
                Participants = new List<Participant> {
                    new Participant { Name = "Elena", Avatar = "user3.png", Action = "joined" }
                },
                Comments = new List<Comment>
                {
                    new Comment { UserName="Elena", Text="Is it for beginners?", UserAvatar="user3.png" }
                }
            }
        };
    }
}
