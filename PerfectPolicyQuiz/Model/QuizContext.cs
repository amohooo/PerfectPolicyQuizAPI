using Microsoft.EntityFrameworkCore;
using System;

namespace PerfectPolicyQuiz.Model
{
    public class QuizContext : DbContext
    {
        public QuizContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<UserInfo> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserInfo>().HasData(
                new UserInfo
                {
                    UserInfoId = 1,
                    UserName = "AdminPerfectPolicies",
                    Password = "PerfectPolicies!22"
                },
                new UserInfo
                {
                    UserInfoId = 2,
                    UserName = "Steve",
                    Password = "AAA"
                });
            builder.Entity<Quiz>().HasData(
                new Quiz
                {
                    QuizId = 1,
                    QuizTopic = "OHS",
                    QuizTitle = "Perfect Quiz Policy",
                    QuizCreatorName = "Steve Jones",
                    CreatingDate = new DateTime(2021, 11, 20),
                    PassPercentage = "100%",
                    UserInfoId = 1
                },
                new Quiz
                {
                    QuizId = 2,
                    QuizTopic = "Copyright",
                    QuizTitle = "Quiz",
                    QuizCreatorName = "Steve Jones",
                    CreatingDate = new DateTime(2021, 11, 20),
                    PassPercentage = "100%",
                    UserInfoId = 1
                },
                new Quiz
                {
                    QuizId = 3,
                    QuizTopic = "Privacy",
                    QuizTitle = "Policy",
                    QuizCreatorName = "Steve",
                    CreatingDate = new DateTime(2021, 11, 20),
                    PassPercentage = "100%",
                    UserInfoId = 2
                }
                );
            builder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionTopic = "Working at Heights",
                    QuestionText = "11. When looking to work at height, Ineed to review:",
                    QuizId = 1
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionTopic = "Client Copyright Materials",
                    QuestionText = "12. With copyright material from our client:",
                    QuizId = 2
                },
                new Question
                {
                    QuestionId = 3,
                    QuestionTopic = "Staff Details",
                    QuestionText = "13. Personal staff details:",
                    QuizId = 3
                },
                new Question
                {
                    QuestionId = 4,
                    QuestionTopic = "Hazards",
                    QuestionText = "14. In the event you notice a potential hazard:",
                    QuizId = 1
                },
                new Question
                {
                    QuestionId = 5,
                    QuestionTopic = "Purchasing Copyright Material",
                    QuestionText = "42. When purchasing copyright material from a third party source:",
                    QuizId = 2
                },
                new Question
                {
                    QuestionId = 6,
                    QuestionTopic = "Incidents",
                    QuestionText = "56. Should you be involved in or be witness to an OHS-related incident, you should:",
                    QuizId = 1
                },
                new Question
                {
                    QuestionId = 7,
                    QuestionTopic = "Internal Copyright Materials",
                    QuestionText = "71. With our organisation's copyright material:",
                    QuizId = 2
                },
                new Question
                {
                    QuestionId = 8,
                    QuestionTopic = "Confined Space Work",
                    QuestionText = "72. When looking to work in a confined space, I need to review:",
                    QuizId = 1
                },
                new Question
                {
                    QuestionId = 9,
                    QuestionTopic = "Client Details",
                    QuestionText = "82. With Commercial in Confidence Client Details, we are required to:",
                    QuizId = 3
                },
                new Question
                {
                    QuestionId = 10,
                    QuestionTopic = "First Aid Kit",
                    QuestionText = "87. In relation to the First Aid Kits in the various departments:",
                    QuizId = 1
                }
                );
            builder.Entity<Option>().HasData(
                new Option
                {
                    OptionId = 1,
                    OptionLetter = "a.",
                    OptionText = "Our Company's SOP - Working at Heights",
                    IsCorrect = true,
                    QuestionId = 1,
                },
                new Option
                {
                    OptionId = 2,
                    OptionLetter = "b.",
                    OptionText = "Our Company's Privacy Policy",
                    IsCorrect = false,
                    QuestionId = 1,
                },
                new Option
                {
                    OptionId = 3,
                    OptionLetter = "c.",
                    OptionText = "Our Chemical Safety Data Sheets",
                    IsCorrect = false,
                    QuestionId = 1,
                },
                new Option
                {
                    OptionId = 4,
                    OptionLetter = "d.",
                    OptionText = "Our Company's Copyright Policy",
                    IsCorrect = false,
                    QuestionId = 1,
                },
                new Option
                {
                    OptionId = 5,
                    OptionLetter = "e.",
                    OptionText = "Our Company's Purchasing Policy",
                    IsCorrect = false,
                    QuestionId = 1,
                },
                new Option
                {
                    OptionId = 6,
                    OptionLetter = "a.",
                    OptionText = "Only store in hard copy in a locked filing cabinet",
                    IsCorrect = false,
                    QuestionId = 2,
                },
                new Option
                {
                    OptionId = 7,
                    OptionLetter = "b.",
                    OptionText = "Store such materials only on our secured network",
                    IsCorrect = true,
                    QuestionId = 2,
                }, 
                new Option
                {
                    OptionId = 8,
                    OptionLetter = "c.",
                    OptionText = "Obfuscate it so as to make it difficult to interpret",
                    IsCorrect = false,
                    QuestionId = 2,
                }, 
                new Option
                {
                    OptionId = 9,
                    OptionLetter = "d.",
                    OptionText = "Restrict viewing to only admin staff",
                    IsCorrect = false,
                    QuestionId = 2,
                }, 
                new Option
                {
                    OptionId = 10,
                    OptionLetter = "e.",
                    OptionText = "Forward to other developers via email",
                    IsCorrect = false,
                    QuestionId = 2,
                }, 
                new Option
                {
                    OptionId = 11,
                    OptionLetter = "a.",
                    OptionText = "Should never be viewed by any staff at any level",
                    IsCorrect = false,
                    QuestionId = 3,
                }, 
                new Option
                {
                    OptionId = 12,
                    OptionLetter = "b.",
                    OptionText = "Can only be viewed by Human Resourses staff",
                    IsCorrect = false,
                    QuestionId = 3,
                }, 
                new Option
                {
                    OptionId = 13,
                    OptionLetter = "c.",
                    OptionText = "Need to be managed in our company's secured database system",
                    IsCorrect = true,
                    QuestionId = 3,
                }, 
                new Option
                {
                    OptionId = 14,
                    OptionLetter = "d.",
                    OptionText = "Should only ever be emailed",
                    IsCorrect = false,
                    QuestionId = 3,
                }, 
                new Option
                {
                    OptionId = 15,
                    OptionLetter = "e.",
                    OptionText = "Should only be stored in hard copy in locked filing cabinets",
                    IsCorrect = false,
                    QuestionId = 3,
                }, 
                new Option
                {
                    OptionId = 16,
                    OptionLetter = "a.",
                    OptionText = "Note it for later consideration",
                    IsCorrect = false,
                    QuestionId = 4,
                }, 
                new Option
                {
                    OptionId = 17,
                    OptionLetter = "b.",
                    OptionText = "Report it immediately to an OHS officer",
                    IsCorrect = true,
                    QuestionId = 4,
                }, 
                new Option
                {
                    OptionId = 18,
                    OptionLetter = "c.",
                    OptionText = "Fill out a Safety Data Sheet",
                    IsCorrect = false,
                    QuestionId = 4,
                }, 
                new Option
                {
                    OptionId = 19,
                    OptionLetter = "d.",
                    OptionText = "Add it to our Company's Purchasing Policy",
                    IsCorrect = false,
                    QuestionId = 4,
                }, 
                new Option
                {
                    OptionId = 20,
                    OptionLetter = "e.",
                    OptionText = "Create a new SOP (Safe Operating Procedure)",
                    IsCorrect = false,
                    QuestionId = 4,
                }, 
                new Option
                {
                    OptionId = 21,
                    OptionLetter = "a.",
                    OptionText = "Request copyright ownership where appropriate and feasible to do so",
                    IsCorrect = true,
                    QuestionId = 5,
                }, 
                new Option
                {
                    OptionId = 22,
                    OptionLetter = "b.",
                    OptionText = "Only purchase material where we can hold the copyright",
                    IsCorrect = false,
                    QuestionId = 5,
                }, 
                new Option
                {
                    OptionId = 23,
                    OptionLetter = "c.",
                    OptionText = "Only purchase material where our clients can hold the copyright",
                    IsCorrect = false,
                    QuestionId = 5,
                }, 
                new Option
                {
                    OptionId = 24,
                    OptionLetter = "d.",
                    OptionText = "Retain a copy of the privacy statement attached to the material purchased",
                    IsCorrect = false,
                    QuestionId = 5,
                }, 
                new Option
                {
                    OptionId = 25,
                    OptionLetter = "e.",
                    OptionText = "Create a new purchasing policy specific to that purchase",
                    IsCorrect = false,
                    QuestionId = 5,
                }, 
                new Option
                {
                    OptionId = 26,
                    OptionLetter = "a.",
                    OptionText = "Note it for later consideration",
                    IsCorrect = false,
                    QuestionId = 6,
                }, 
                new Option
                {
                    OptionId = 27,
                    OptionLetter = "b.",
                    OptionText = "Fill out a Safety Data Sheet",
                    IsCorrect = false,
                    QuestionId = 6,
                },
                new Option
                {
                    OptionId = 28,
                    OptionLetter = "c.",
                    OptionText = "Add it to our Company's Purchasing Policy",
                    IsCorrect = false,
                    QuestionId = 6,
                }, 
                new Option
                {
                    OptionId = 29,
                    OptionLetter = "d.",
                    OptionText = "Report it immediately to an OHS or security officer",
                    IsCorrect = true,
                    QuestionId = 6,
                }, 
                new Option
                {
                    OptionId = 30,
                    OptionLetter = "e.",
                    OptionText = "Our Company's Purchasing Policy",
                    IsCorrect = false,
                    QuestionId = 6,
                }, 
                new Option
                {
                    OptionId = 31,
                    OptionLetter = "a.",
                    OptionText = "Obfuscate it so as to make it difficult to interpret",
                    IsCorrect = false,
                    QuestionId = 7,
                }, 
                new Option
                {
                    OptionId = 32,
                    OptionLetter = "b.",
                    OptionText = "Restrict viewing to only admin staff",
                    IsCorrect = false,
                    QuestionId = 7,
                }, 
                new Option
                {
                    OptionId = 33,
                    OptionLetter = "c.",
                    OptionText = "Only store in hard copy in a locked filing cabinet",
                    IsCorrect = false,
                    QuestionId = 7,
                }, 
                new Option
                {
                    OptionId = 34,
                    OptionLetter = "d.",
                    OptionText = "Store such materials only on our secured network",
                    IsCorrect = true,
                    QuestionId = 7,
                }, 
                new Option
                {
                    OptionId = 35,
                    OptionLetter = "e.",
                    OptionText = "Forward to other developers via email",
                    IsCorrect = false,
                    QuestionId = 7,
                }, 
                new Option
                {
                    OptionId = 36,
                    OptionLetter = "a.",
                    OptionText = "Our company's SOP - Working at Heights",
                    IsCorrect = false,
                    QuestionId = 8,
                }, 
                new Option
                {
                    OptionId = 37,
                    OptionLetter = "b.",
                    OptionText = "Our company's SOP - Vehicle Parking",
                    IsCorrect = false,
                    QuestionId = 8,
                }, 
                new Option
                {
                    OptionId = 38,
                    OptionLetter = "c.",
                    OptionText = "Our Chemical Safety Data Sheets",
                    IsCorrect = false,
                    QuestionId = 8,
                }, 
                new Option
                {
                    OptionId = 39,
                    OptionLetter = "d.",
                    OptionText = "Our Company's Copyright Policy",
                    IsCorrect = false,
                    QuestionId = 8,
                }, 
                new Option
                {
                    OptionId = 40,
                    OptionLetter = "e.",
                    OptionText = "Our company's SOP - Working in a Confined Space",
                    IsCorrect = true,
                    QuestionId = 8,
                }, 
                new Option
                {
                    OptionId = 41,
                    OptionLetter = "a.",
                    OptionText = "Store such details only on our secured network",
                    IsCorrect = true,
                    QuestionId = 9,
                }, 
                new Option
                {
                    OptionId = 42,
                    OptionLetter = "b.",
                    OptionText = "Only store in hard copy in a locked filing cabinet",
                    IsCorrect = false,
                    QuestionId = 9,
                }, 
                new Option
                {
                    OptionId = 43,
                    OptionLetter = "c.",
                    OptionText = "Obfuscate it so as to make it difficult to interpret",
                    IsCorrect = false,
                    QuestionId = 9,
                }, 
                new Option
                {
                    OptionId = 44,
                    OptionLetter = "d.",
                    OptionText = "Can only be viewed by admin staff",
                    IsCorrect = false,
                    QuestionId = 9,
                }, 
                new Option
                {
                    OptionId = 45,
                    OptionLetter = "e.",
                    OptionText = "Can be left unsecured",
                    IsCorrect = false,
                    QuestionId = 9,
                }, 
                new Option
                {
                    OptionId = 46,
                    OptionLetter = "a.",
                    OptionText = "Leave them wherever last used",
                    IsCorrect = false,
                    QuestionId = 10,
                }, 
                new Option
                {
                    OptionId = 47,
                    OptionLetter = "b.",
                    OptionText = "Place them above the stovetops in the department kitchens",
                    IsCorrect = false,
                    QuestionId = 10,
                }, 
                new Option
                {
                    OptionId = 48,
                    OptionLetter = "c.",
                    OptionText = "Ensure they are kept appropriately stocked",
                    IsCorrect = true,
                    QuestionId = 10,
                }, 
                new Option
                {
                    OptionId = 49,
                    OptionLetter = "d.",
                    OptionText = "Only display appropriate signage when directed to do so",
                    IsCorrect = false,
                    QuestionId = 10,
                }, 
                new Option
                {
                    OptionId = 50,
                    OptionLetter = "e.",
                    OptionText = "Fill out a Safety Data Sheet with each use",
                    IsCorrect = false,
                    QuestionId = 10,
                }
                );
        }
    }
}
