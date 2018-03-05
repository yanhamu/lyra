using Lyra.DataAccess.Model;
using Lyra.DataAccess.Repositories;
using Lyra.Services.Common;
using Lyra.Web.Services.Flow;
using NSubstitute;
using System;
using Xunit;

namespace Lyra.Web.Tests.Services.Flow
{
    public class NextStepCommandFactoryTest
    {
        private readonly Guid userId = Guid.NewGuid();
        private IPlayerRepository playerRepository;
        private IRealmService realmService;
        private NextStepCommandFactory factory;

        public NextStepCommandFactoryTest()
        {
            playerRepository = Substitute.For<IPlayerRepository>();
            realmService = Substitute.For<IRealmService>();
            factory = new NextStepCommandFactory(playerRepository, realmService);
        }

        [Fact]
        public void Should_Continue()
        {
            realmService.IsValid(Arg.Any<Guid>()).Returns(true);
            playerRepository.GetActivePlayer(userId).Returns(new Player() { IsActive = true });

            var command = factory.Create(userId);

            Assert.Null(command);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Should_Redirect_To_HallOfFame(bool isActive)
        {
            realmService.IsValid(Arg.Any<Guid>()).Returns(false);
            playerRepository.GetActivePlayer(userId).Returns(new Player() { IsActive = isActive });

            var command = factory.Create(userId);

            Assert.IsType<RealmEnded>(command);
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void Should_Redirect_To_Setup_New_Nation(bool isValid)
        {
            realmService.IsValid(Arg.Any<Guid>()).Returns(isValid);
            playerRepository.GetActivePlayer(userId).Returns(default(Player));

            var command = factory.Create(userId);

            Assert.IsType<SetupNewNation>(command);
        }
    }
}
