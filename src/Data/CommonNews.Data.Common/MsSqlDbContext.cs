namespace CommonNews.Data.Common
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Bytes2you.Validation;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Contracts;

    public class MsSqlDbContext : IdentityDbContext<ApplicationUser>/*, IMsSqlDbContext*/
    {
        //private IStateFactory stateFactory;

        public MsSqlDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        //public MsSqlDbContext(IStateFactory stateFactory)
        //    : base("MeetMeDB")
        //{
        //    Guard.WhenArgument(stateFactory, "StateFactory").IsNull().Throw();

        //    this.stateFactory = stateFactory;
        //}

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<PostCategory> PostCategories { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            //try
            //{
                return base.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    // Retrieve the error messages as a list of strings.
            //    var errorMessages = ex.EntityValidationErrors
            //            .SelectMany(x => x.ValidationErrors)
            //            .Select(x => x.ErrorMessage);

            //    // Join the list to a single string.
            //    var fullErrorMessage = string.Join("; ", errorMessages);

            //    // Combine the original exception message with the new one.
            //    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

            //    // Throw a new DbEntityValidationException with the improved exception message.
            //    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            //}
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer(new MigrateDatabaseToLatestVersion<MsSqlDbContext, Configuration>());
        //    base.OnModelCreating(modelBuilder);
        //}

        //public IEntryState<T> GetState<T>(T entity)
        //    where T : class
        //{
        //    return this.stateFactory.CreateState(this.Entry(entity));
        //}

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
