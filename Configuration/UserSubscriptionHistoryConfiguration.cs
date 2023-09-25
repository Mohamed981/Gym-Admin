using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Configuration
{
    public class UserSubscriptionHistoryConfiguration : IEntityTypeConfiguration<UserSubscriptionHistory>
    {
        public void Configure(EntityTypeBuilder<UserSubscriptionHistory> builder)
        {
            builder.ToTable("usersubscriptionhistory");
            builder.HasQueryFilter(m => m.IsDeleted == false);
        }
    }
}
