using Communication.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Communication.BusinessLayer.Configurations
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasOne(x => x.RequestFrom).WithMany(x => x.SendToBeFriends)
                .HasForeignKey(x => x.RequestFromId).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(x => x.Id);
            builder.HasOne(x => x.RequestTo).WithMany(x => x.ReceiveToBeFriends)
                .HasForeignKey(x => x.RequestToId).OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey(x => x.Id); ;
        }
    }
}
