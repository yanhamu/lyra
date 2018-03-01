using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lyra.Services.Features.RegisterCountry
{
    public class RegisterCountryHandler : IRequestHandler<RegisterCountryCommand, Guid>
    {
        public RegisterCountryHandler()
        {

        }

        public Task<Guid> Handle(RegisterCountryCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();   
        }
    }
}
