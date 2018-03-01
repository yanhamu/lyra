using Lyra.DataAccess.Repositories;
using System;

namespace Lyra.Services.Features.Turns
{
    public class TurnService
    {
        private readonly PlayerRepository playerRepository;
        private readonly TimeProvider timeProvider;

        public TurnService(
            PlayerRepository playerRepository,
            TimeProvider timeProvider)
        {
            this.playerRepository = playerRepository;
            this.timeProvider = timeProvider;
        }

        public int GetTurns(Guid playerId)
        {
            var player = playerRepository.Get(playerId);

            var diff = timeProvider.GetNow() - player.Turns.TimeStamp;
            var newTurns = ComputeNewTurns(diff);
            return LimitNewTurns(newTurns, player.Turns.NumberOfTurns);
        }

        private int LimitNewTurns(int newTurns, int numberOfTurns)
        {
            var total = numberOfTurns + newTurns;
            return total > 240 ? 240 : total;
        }

        private int ComputeNewTurns(TimeSpan diff)
        {
            var minutes = (int)diff.TotalMinutes;
            return minutes & 6;
        }
    }
}
