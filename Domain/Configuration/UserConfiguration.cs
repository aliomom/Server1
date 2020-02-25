
using Domain.Entity.WiEntity;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Configuration
{
    internal class UserConfiguration : EntityTypeConfiguration<AspNetUser>
    {
        internal UserConfiguration()
        {
            ToTable("AspNetUser");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("Id")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsOptional();

            Property(x => x.EmailConfirmed)
                .HasColumnName("EmailConfirmed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.SecurityStamp)
                .HasColumnName("SecurityStamp")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.PhoneNumber)
                .HasColumnName("PhoneNumber")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.PhoneNumberConfirmed)
                .HasColumnName("PhoneNumberConfirmed")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.TwoFactorEnabled)
                .HasColumnName("TwoFactorEnabled")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.LockoutEndDateUtc)
                .HasColumnName("LockoutEndDateUtc")
                .HasColumnType("datetime")
                .HasPrecision(23)
                .IsOptional();

            Property(x => x.LockoutEnabled)
                .HasColumnName("LockoutEnabled")
                .HasColumnType("bit")
                .IsRequired();

            Property(x => x.AccessFailedCount)
                .HasColumnName("AccessFailedCount")
                .HasColumnType("int")
                .IsRequired();

            Property(x => x.UserName)
                .HasColumnName("UserName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasColumnType("nvarchar")
                .HasMaxLength(256)
                .IsRequired();

            HasMany(x => x.AspNetRoles)
                .WithMany(x => x.AspNetUsers)
                .Map(x =>
                {
                    x.ToTable("UserRole");
                    x.MapLeftKey("UserId");
                    x.MapRightKey("RoleId");
                });

            HasMany(x => x.AspNetUserClaims)
                .WithRequired(x => x.AspNetUser)
                .HasForeignKey(x => x.UserId);

            HasMany(x => x.AspNetUserLogins)
                .WithRequired(x => x.AspNetUser)
                .HasForeignKey(x => x.UserId);

           

        }
    }
}
