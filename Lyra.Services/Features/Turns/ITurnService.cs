using System;

namespace Lyra.Services.Features.Turns
{
    public interface ITurnService
    {
        int ComputeNewTurns(DateTime now, DateTime lastTime);
        int GetTurns(Guid playerId);
    }
}