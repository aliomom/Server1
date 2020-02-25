
using Domain.Entity.WiEntity;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Configuration
{
    internal class LoginConfiguration : EntityTypeConfiguration<AspNetUserLogin>
    {
        internal LoginConfiguration()
        {
            ToTable("AspNetUserLogin");

            HasKey(x => new { x.LoginProvider, x.ProviderKey, x.UserId });

            Property(x => x.LoginProvider)
                .HasColumnName("LoginProvider")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.ProviderKey)
                .HasColumnName("ProviderKey")
                .HasColumnType("nvarchar")
                .HasMaxLength(128)
                .IsRequired();

            Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            HasRequired(x => x.AspNetUser)
                .WithMany(x => x.AspNetUserLogins)
                .HasForeignKey(x => x.UserId);
        }
    }
}
