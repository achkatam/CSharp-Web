namespace TaskboardApplication.Data.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = Models.Task;
internal class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

        ICollection<Task> tasks = GenerateTasks();

            builder
                .HasData(tasks);
        }

        private ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS style",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.Now.AddDays(-200),
                    OwnerId = "4553774c-937a-4a55-a581-676932e6dc3f",
                    BoardId = 1
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.Now.AddMonths(-5),
                    OwnerId = "aa63a446-69bd-4e74-a35a-27544bfcc75b",
                    BoardId = 1
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop Client app",
                    Description = "Create Windows Forms desktop app client for the TaskBoard RESTful API",
                    CreatedOn = DateTime.Now.AddMonths(-1),
                    OwnerId = "4553774c-937a-4a55-a581-676932e6dc3f",
                    BoardId = 2
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding new tasks",
                    CreatedOn = DateTime.Now.AddYears(-1),
                    OwnerId = "4553774c-937a-4a55-a581-676932e6dc3f",
                    BoardId = 3
                }
            };

            return tasks;
        }
    }
