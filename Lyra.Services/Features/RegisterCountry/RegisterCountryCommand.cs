using MediatR;
using System;

namespace Lyra.Services.Features.RegisterCountry
{
    public class RegisterCountryCommand : IRequest<Guid>
    {
        public string PlayerName { get; set; }
        public string CountryName { get; set; }
        public Guid UserId { get; set; }

        public RegisterCountryCommand(string playerName, string countryName, Guid userId)
        {
            this.PlayerName = playerName;
            this.CountryName = countryName;
            this.UserId = userId;
        }
    }
}