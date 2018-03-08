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
            realmService.GetActiveRealm().Returns(new Realm());
            playerRepository.GetPlayerForRealm(Arg.Any<Guid>(), Arg.Any<Guid>()).Returns(new Player());

            var command = factory.Create(userId);

            Assert.IsType<NullCommand>(command);
        }

        [Fact]
        public void Should_Redirect_To_Meanwhile()
        {
            realmService.GetActiveRealm().Returns(default(Realm));

            var command = factory.Create(userId);

            Assert.IsType<RedirectToMeanWhile>(command);
        }

        [Fact]
        public void Should_Redirect_To_Register_Country()
        {
            var realmId = Guid.NewGuid();
            realmService.GetActiveRealm().Returns(new Realm { Id = realmId });
            playerRepository.GetPlayerForRealm(userId, Arg.Any<Guid>()).Returns(default(Player));

            var command = factory.Create(userId);

            Assert.IsType<RedirectToRegisterCountry>(command);
        }
    }
}
