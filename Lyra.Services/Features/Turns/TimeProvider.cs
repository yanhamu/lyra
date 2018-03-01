using System;

namespace Lyra.Services.Features.Turns
{
    public class TimeProvider
    {
        public DateTime GetNow()
        {
            return DateTime.UtcNow;
        }
    }
}
