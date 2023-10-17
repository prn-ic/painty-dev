using Communication.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Communication.BusinessLayer.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property("PasswordHash");
            builder.Property("PasswordSalt");
            builder.Property("Images").HasColumnName("_images");
            builder.HasOne(o => o.Role);
        }
    }
}
