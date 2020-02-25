
using Domain.Entity.WiEntity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Configuration
{
    internal class ClaimConfiguration : EntityTypeConfiguration<AspNetUserClaim>
    {
        internal ClaimConfiguration()
        {
            ToTable("AspNetUserClaim");

            HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasColumnName("ClaimId")
                .HasColumnType("int")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasColumnType("uniqueidentifier")
                .IsRequired();

            Property(x => x.ClaimType)
                .HasColumnName("ClaimType")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            Property(x => x.ClaimValue)
                .HasColumnName("ClaimValue")
                .HasColumnType("nvarchar")
                .IsMaxLength()
                .IsOptional();

            HasRequired(x => x.AspNetUser)
                .WithMany(x => x.AspNetUserClaims)
                .HasForeignKey(x => x.UserId);
        }
    }
}
