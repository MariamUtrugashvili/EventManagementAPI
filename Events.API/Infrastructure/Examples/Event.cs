using Events.Application.Events.Requests;
using Events.Application.Events.Responses;
using Swashbuckle.AspNetCore.Filters;

namespace Events.API.Infrastructure.Examples
{
    public class Event
    {
        public class EventPostExamples : IMultipleExamplesProvider<EventRequestPostModel>
        {
            public IEnumerable<SwaggerExample<EventRequestPostModel>> GetExamples()
            {
                yield return SwaggerExample.Create("example 1", new EventRequestPostModel
                {
                    Title = "მოვეფეროთ ფისოებს",
                    Description = "ივენთი განკუთვნილია ყველა იმ ადამინისთვის" +
                    "ვისაც ფისოები უყვარს",
                    TicketQuantity = 100,
                    StartTime = DateTime.Now.AddHours(8),
                    EndTime = DateTime.Now.AddHours(12),
                });

                yield return SwaggerExample.Create("example 2", new EventRequestPostModel
                {
                    Title = "Mad Mozart",
                    Description = "The Mad Mozart symphonic band performs the instrumental" +
                    " show that leaves no one indifferent.",
                    TicketQuantity = 50,
                    StartTime = DateTime.Now.AddHours(15),
                    EndTime = DateTime.Now.AddHours(20),
                });
            }

        }
        public class EventPutExamples : IMultipleExamplesProvider<EventRequestPutModel>
        {
            public IEnumerable<SwaggerExample<EventRequestPutModel>> GetExamples()
            {
                yield return SwaggerExample.Create("example 1", new EventRequestPutModel
                {
                    Id = 1,
                    Title = "მოვეფეროთ ფისოებს",
                    Description = "ივენთი განკუთვნილია ყველა იმ ადამინისთვის" +
                    "ვისაც ფისოები უყვარს",
                    TicketQuantity = 100,
                    StartTime = DateTime.Now.AddHours(8),
                    EndTime = DateTime.Now.AddHours(12),
                });

                yield return SwaggerExample.Create("example 2", new EventRequestPutModel
                {
                    Id = 2,
                    Title = "Mad Mozart",
                    Description = "The Mad Mozart symphonic band performs the instrumental" +
                    " show that leaves no one indifferent.",
                    TicketQuantity = 50,
                    StartTime = DateTime.Now.AddHours(15),
                    EndTime = DateTime.Now.AddHours(20),
                });
            }

        }
        public class EventResponseExamples : IMultipleExamplesProvider<EventResponseModel>
        {
            public IEnumerable<SwaggerExample<EventResponseModel>> GetExamples()
            {
                yield return SwaggerExample.Create("example 1", new EventResponseModel
                {
                    Title = "მოვეფეროთ ფისოებს",
                    Description = "ივენთი განკუთვნილია ყველა იმ ადამინისთვის" +
                    "ვისაც ფისოები უყვარს",
                    TicketQuantity = 100,
                    StartTime = DateTime.Now.AddHours(8),
                    EndTime = DateTime.Now.AddHours(12),
                });

                yield return SwaggerExample.Create("example 2", new EventResponseModel
                {
                    Title = "Mad Mozart",
                    Description = "The Mad Mozart symphonic band performs the instrumental" +
                    " show that leaves no one indifferent.",
                    TicketQuantity = 50,
                    StartTime = DateTime.Now.AddHours(15),
                    EndTime = DateTime.Now.AddHours(20),
                });
            }

        }
        public class UnpublishedEventResponseExamples : IMultipleExamplesProvider<UnpublishedEventResponseModel>
        {
            public IEnumerable<SwaggerExample<UnpublishedEventResponseModel>> GetExamples()
            {
                yield return SwaggerExample.Create("example 1", new UnpublishedEventResponseModel
                {
                    Id = 1,
                    UserId = "791f184c-8c1c-44e9-8556-6c5654c51e4a",
                    Title = "Killages სოლო კონცერტი დედაენის ბარში",
                    Description = "ხანგრძლივი პაუზის შემდეგ Killages სოლო კონცერტით ბრუნდება," +
                    " ბევრი ძველი და ცოტა ახალი სიმღერით.",
                    IsAccepted = false
                }); ;

                yield return SwaggerExample.Create("example 2", new UnpublishedEventResponseModel
                {
                    Id = 2,
                    UserId = "3f88c27e-a56c-42bd-b2c7-fa1e2fffc517",
                    Title = "Music Saves the World vol.2",
                    Description = "24 მარტს მუსიკისა და თეატრის ვარსკვლავები ერთსა და იმავე სივრცეში " +
                    "ერთ საღამოს გაერთიანდებიან Club DUST-ში",
                    IsAccepted = false
                });
            }

        }
    }
}

