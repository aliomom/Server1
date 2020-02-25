using Domain.Entity.WiEntity;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Configuration
{
    internal class RoleConfiguration : EntityTypeConfiguration<AspNetRole>
    {
        internal RoleConfiguration()
        {
            ToTable("AspNetRole");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("RoleId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.AspNetUsers)
                .WithMany(x => x.AspNetRoles)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("UserId");
                });
        }
    }
}
