using Communication.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Communication.BusinessLayer.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasOne(x => x.RequestFrom).WithMany(x => x.Friends);
            builder.HasOne(x => x.RequestTo).WithMany(x => x.Friends);
        }
    }
}
