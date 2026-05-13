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
        // await Task.Delay(100);

        return new List<Event>
        {
            // СОБЫТИЕ 1: ФУТБОЛ
            new Event {
                Title = "Football",
                Category = "Sport",
                ImageSource = "football_scroll_1.jpg",
                Description = "Football match.",
                TimeLocation = "Today 4PM •  📍Trastevere",
                GoalAmount = 20,
                CurrentFunded = 15,
                GoalDescription = "Court/Ball",
                Participants = new List<Participant> {
                    new Participant { Name = "Sarah", Avatar = "user1.jpg", Action = "joined" },
                    new Participant { Name = "Mark", Avatar = "user2.jpg", Action = "funded $5" },
                    new Participant { Name = "Maya", Avatar = "user3.jpg", Action = "joined" }
                },
                 Comments = new List<Comment>
                {
                    new Comment { UserName="Sarah", Text="I'm coming with 2 friends!", UserAvatar="user1.jpg" },
                    new Comment { UserName="Marco", Text="Do we have a ball?", UserAvatar="user2.jpg" }
                }
            },

            // СОБЫТИЕ 2: ИСТОРИЯ (Бесплатно или дешево)
            new Event {
                Title = "Roman History",
                Category = "Study",
                ImageSource = "library_scroll.jpg",
                Description = "Exam preparation.",
                TimeLocation = "Tomorrow 2PM • 📍Sapienza",
                GoalAmount = 5,
                CurrentFunded = 2,
                GoalDescription = "Print materials",
                Participants = new List<Participant> {
                    new Participant { Name = "Prof. Rossi", Avatar = "user4.jpg", Action = "joined" },
                    new Participant { Name = "Luca", Avatar = "user2.jpg", Action = "funded $2" }
                },
                Comments = new List<Comment>
                {
                    new Comment { UserName="Prof. Rossi", Text="I can help with materials.", UserAvatar="user4.jpg" }
                }
            },

            // СОБЫТИЕ 3: БЕГ (Без сбора денег)
            new Event {
                Title = "Running",
                Category = "Sport",
                ImageSource = "running_scroll.jpg",
                Description = "Morning run.",
                TimeLocation = "Today 6AM • 📍Parioli",
                GoalAmount = 0,
                CurrentFunded = 0,
                GoalDescription = "Free event",
                Participants = new List<Participant> {
                    new Participant { Name = "Elena", Avatar = "user3.jpg", Action = "joined" }
                },
                Comments = new List<Comment>
                {
                    new Comment { UserName="Elena", Text="Is it for beginners?", UserAvatar="user3.jpg" }
                }
            },
            // СОБЫТИЕ 4: concert
            new Event {
                Title = "Rock Night in Trastevere",
                Category = "Entertainment",
                ImageSource = "concert_scroll.jpg",
                Description = "Concert: Maneskin Tribute",
                TimeLocation = "Today 9PM • 📍Circolo degli Artisti",
                GoalAmount = 40,
                CurrentFunded = 30,
                GoalDescription = "Cheap event",
                Participants = new List<Participant> {
                    new Participant { Name = "Kate", Avatar = "user1.jpg", Action = "joined" },
                    new Participant { Name = "Max", Avatar = "user2.jpg", Action = "joined" },
                    new Participant { Name = "Sam", Avatar = "user3.jpg", Action = "joined" }

                },
                Comments = new List<Comment>
                {
                    new Comment { UserName="Mark", Text="Wow, so interesting", UserAvatar="user3.jpg" }
                }
            },
             // СОБЫТИЕ 5: хайкинг
            new Event {
                Title = "Weekend Hike",
                Category = "Sport",
                ImageSource = "hiking_scroll.jpg",
                Description = "Beautiful view.",
                TimeLocation = "Synday, 9AM • Zodiaco Viewpoint",
                GoalAmount = 0,
                CurrentFunded = 0,
                GoalDescription = "Free event",
                Participants = new List<Participant> {
                    new Participant { Name = "Elena", Avatar = "user3.jpg", Action = "joined" }
                },
                Comments = new List<Comment>
                {
                    new Comment { UserName="Mark", Text="Wow, so interesting", UserAvatar="user3.jpg" }
                }
            }

        };
    }
}
