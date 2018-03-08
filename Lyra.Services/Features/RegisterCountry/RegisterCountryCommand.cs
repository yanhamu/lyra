using MediatR;
using System;

namespace Lyra.Services.Features.RegisterCountry
{
    public class RegisterCountryCommand : IRequest<Guid>
    {
        public string PlayerName { get; private set; }
        public string CountryName { get; private set; }
        public Guid UserId { get; private set; }

        public RegisterCountryCommand(string playerName, string countryName, Guid userId)
        {
            this.PlayerName = playerName;
            this.CountryName = countryName;
            this.UserId = userId;
        }
    }
}