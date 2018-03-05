﻿using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using System;

namespace Lyra.Services.Features.Turns
{
    public class TurnService : ITurnService
    {
        private readonly Repository<Player> playerRepository;
        private readonly ITimeProvider timeProvider;

        public TurnService(
            Repository<Player> playerRepository,
            ITimeProvider timeProvider)
        {
            this.playerRepository = playerRepository;
            this.timeProvider = timeProvider;
        }

        public int GetTurns(Guid playerId)
        {
            var player = playerRepository.Get(playerId);

            var newTurns = ComputeNewTurns(timeProvider.GetNow(), player.Turns.TimeStamp);
            return LimitNewTurns(newTurns, player.Turns.NumberOfTurns);
        }

        public int ComputeNewTurns(DateTime now, DateTime lastTime)
        {
            var diff = now - lastTime;
            var minutes = (int)diff.TotalMinutes;
            return minutes % 6;
        }

        private int LimitNewTurns(int newTurns, int numberOfTurns)
        {
            var total = numberOfTurns + newTurns;
            return total > 240 ? 240 : total;
        }

    }
}
