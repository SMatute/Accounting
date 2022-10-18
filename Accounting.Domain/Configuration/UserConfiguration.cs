using Accounting.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Accounting.Domain.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration <User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            

            builder.Property(p => p.UserName).HasMaxLength(25);
            builder.Property(p => p.Password).HasMaxLength(50);
               
           
        }
    }
}
