using System.Data.Entity;

namespace TriviaGame.Models
{
    public class TriviaDbContext : DbContext
    {
        private static bool _created = false;

        public TriviaDbContext()
        {
            /*if (!_created)
            {
                _created = true;
                //Database.EnsureCreated();
                Database.CreateIfNotExists();
            }*/
            Database.SetInitializer(new SampleData());
            //Database.SetInitializer<TriviaDbContext>(new CreateDatabaseIfNotExists<TriviaDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<TriviaOption>()
                .HasKey(o => new { o.QuestionId, o.Id });

            /*builder.Entity<TriviaAnswer>()
                .HasOne(a => a.TriviaOption)
                .WithMany()
                .HasForeignKey(a => new { a.QuestionId, a.OptionId });*/

            builder.Entity<TriviaAnswer>()
                .HasRequired(a => a.TriviaOption)
                .WithMany()
                .HasForeignKey(a => new { a.QuestionId, a.OptionId });

            builder.Entity<TriviaQuestion>()
                .HasMany(q => q.Options)
                .WithRequired(o => o.TriviaQuestion);
        }
        
        public DbSet<TriviaQuestion> TriviaQuestions { get; set; }

        public DbSet<TriviaOption> TriviaOptions { get; set; }

        public DbSet<TriviaAnswer> TriviaAnswers { get; set; }
    }
}
