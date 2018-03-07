using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using Lyra.Services.Common;
using Lyra.Services.Features.Turns;
using NSubstitute;
using System;
using Xunit;

namespace Lyra.Services.Tests.Features.Turns
{
    public class TurnServiceTests
    {
        private IRepository<Player> playerRepository;
        private ITimeProvider timeProvider;
        private TurnService turnService;

        public TurnServiceTests()
        {
            playerRepository = Substitute.For<IRepository<Player>>();
            timeProvider = Substitute.For<ITimeProvider>();
            turnService = new TurnService(playerRepository, timeProvider);
        }

        [Fact]
        public void Should_Compute_New_Turns()
        {
            var now = new DateTime(2017, 1, 1, 10, 0, 0);
            var lastTime = new DateTime(2017, 1, 1, 9, 0, 0);

            var newTurns = turnService.ComputeNewTurns(now, lastTime);
            Assert.Equal(10, newTurns);
        }

        [Fact]
        public void Should_Compute_New_Turns_Rounded()
        {
            Assert.Equal(9, turnService.ComputeNewTurns(
                new DateTime(2017, 1, 1, 10, 0, 0),
                new DateTime(2017, 1, 1, 9, 1, 0)));

            Assert.Equal(10, turnService.ComputeNewTurns(
                new DateTime(2017, 1, 1, 10, 1, 0),
                new DateTime(2017, 1, 1, 9, 0, 0)));
        }
    }
}