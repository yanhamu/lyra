using System;

namespace Lyra.DataAccess.Model
{
    public class Player
    {
        public int PlayerId { get; set; }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
        public string Name { get; set; }
        public Guid RealmId { get; set; }
        public Realm Realm { get; set; }
        public Turns Turns { get; set; }
        public bool IsActive { get; set; }
    }
}
