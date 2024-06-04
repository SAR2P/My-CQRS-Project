


using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Store.DataAccessLayer.Common
{
    //add shadow properties from dbContext to saveChanges
    public class AddAuditFeildInterceptor : SaveChangesInterceptor
    {



        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            setShadowPropertyValues(eventData);
            return base.SavedChanges(eventData, result);
        }

        public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            setShadowPropertyValues(eventData);
            return base.SavedChangesAsync(eventData, result, cancellationToken);
        }

        public static void setShadowPropertyValues(DbContextEventData eventData)
        {
            var changeTracker = eventData.Context!.ChangeTracker;

            var addedEntities = changeTracker.Entries().Where(
                x => x.State == Microsoft.EntityFrameworkCore.EntityState.Added);

            var updateEntities = changeTracker.Entries().Where(
                x => x.State == Microsoft.EntityFrameworkCore.EntityState.Modified);


            foreach ( var entity in addedEntities )
            {
                entity.Property("CreateBy").CurrentValue = "soheil";
                entity.Property("UpdateBy").CurrentValue = "";
                entity.Property("CreatedDateTime").CurrentValue = DateTime.Now;
                entity.Property("UpdateDateTime").CurrentValue = DateTime.Now;
            }

            foreach ( var entity in updateEntities )
            {
                entity.Property("UpdateBy").CurrentValue = "soheil k";
                entity.Property("UpdateDateTime").CurrentValue= DateTime.Now;
            }

        }

    }
}
