using GM.Application.AppCore.Entities.GovLocations;
using GM.Infrastructure.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class CreateGovLocationCommandHandler : 
        IRequestHandler<CreateGovLocationCommand, int?>

    {
        private readonly IApplicationDbContext _context;

        public CreateGovLocationCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int?> Handle(CreateGovLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = new GovLocation(request.Name, request.Type, request.Code);

            _context.GovLocations.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
