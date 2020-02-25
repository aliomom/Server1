using Domain.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Domain.Configuration
{
    class Test1Configuration: EntityTypeConfiguration<Test1>
    {
        public Test1Configuration()
        {
            ToTable("Test1");
            Property(x => x.Id)
                .HasColumnType("int")
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired()
                ;
            Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .IsOptional();

        }
       
        
    }
}
