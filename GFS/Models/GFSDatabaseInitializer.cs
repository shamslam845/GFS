using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;

namespace GFS.Models
{
    public class GFSDatabaseInitializer : DropCreateDatabaseAlways<GFSContext>
    {
        protected override void Seed(GFSContext context)
        {
            GetFormContainers().ForEach(i => context.FormContainers.Add(i));
            GetSections().ForEach(j => context.Sections.Add(j));
            GetEmails().ForEach(e => context.Emails.Add(e));
            GetFeedbackContainers().ForEach(g => context.FeedbackContainers.Add(g));
            GetFeedbacks().ForEach(f => context.Feedbacks.Add(f));
            GetForms().ForEach(h => context.Forms.Add(h));
        }

        private static List<FormContainer> GetFormContainers()
        {
            var formcontainers = new List<FormContainer>
            {
                new FormContainer
                {
                    FormContainerID = 1,
                    Name = "Questions, Comments",
                    Description = "This is the section for quetions, comments",
                    UserID = "049058e1-965c-40af-adad-5fdd8a15c68c"
                }
            };
            return formcontainers;
        }

        private static List<Section> GetSections()
        {
            var sections = new List<Section>{
                new Section
                {
                    SectionID = 1,
                    SectionNumber = 1,
                    CourseName = "CPSC335",
                    UserID = "049058e1-965c-40af-adad-5fdd8a15c68c",
                    FormContainerID = 1
                }
            };
            return sections;
        }

        private static List<Email> GetEmails()
        {
            var emails = new List<Email>{
                new Email
                {
                    EmailID = 1,
                    EmailAddress = "testing@testing.com",
                    SectionID = 1
                }
            };
            return emails;
        }

        private static List<FeedbackContainer> GetFeedbackContainers()
        {
            DateTime now = DateTime.Now;
            var feedbackcontainers = new List<FeedbackContainer>
            {
                new FeedbackContainer
                {
                    FeedbackContainerID = 1,
                    DateTimes = now,
                    FormContainerID = 1
                }
            };
            return feedbackcontainers;
        }

        private static List<Feedback> GetFeedbacks()
        {
            var feedbacks = new List<Feedback>{
                new Feedback
                {
                    FeedbackID = 1,
                    Message = "Test",
                    UserID = "049058e1-965c-40af-adad-5fdd8a15c68c",
                    FeedbackContainerID = 1,
                    SectionID = 1,
                }
            };
            return feedbacks;
        }

        private static List<Form> GetForms()
        {
            var forms = new List<Form>
            {
                new Form
                {
                    FormID = 1,
                    Title = "Any important questions?",
                    FormType = 1,
                    FormContainerID = 1,
                }
            };
            return forms;
        }
    }
}