using System;

namespace Lyra.DataAccess.Model
{
    public class Realm
    {
        public Guid Id { get; set; }
        public DateTime Beginning { get; set; }
        public DateTime End { get; set; }
    }
}