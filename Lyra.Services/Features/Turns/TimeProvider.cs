using System;

namespace Lyra.Services.Features.Turns
{
    public interface ITimeProvider
    {
        DateTime GetNow();
    }

    public class TimeProvider : ITimeProvider
    {
        public DateTime GetNow()
        {
            return DateTime.UtcNow;
        }
    }
}
