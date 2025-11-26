using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NotificationSystem.Api.Entities;

namespace NotificationSystem.Api.Persistense.EntityConfigurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");

            builder.HasKey(n => n.NotificationId);

            builder.Property(n => n.UserId)
                   .IsRequired(true);
                   
            builder.Property(n => n.Source)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(n => n.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(n => n.Message)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(n => n.CreatedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(n => n.IsRead)
                   .IsRequired()
                   .HasDefaultValue(false);
        }
    }
}
