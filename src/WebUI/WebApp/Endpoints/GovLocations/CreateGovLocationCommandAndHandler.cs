using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.DTOs.GovLocations;
using GM.DatabaseAccess;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class CreateGovLocationCommand : CreateGovLocationDto, IRequest<int?>
    {
    }

    public class CreateGovLocationCommandHandler : 
        IRequestHandler<CreateGovLocationCommand, int?>

    {
        private readonly ApplicationDbContext _context;

        public CreateGovLocationCommandHandler(ApplicationDbContext context)
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

        //public CreateGovLocationCommandHandler() { }
        //public async Task<int?> Handle(CreateGovLocationCommand request, CancellationToken cancellationToken)
        //{
        //    Task task = Task.Delay(1);
        //    await task;
        //    return 1;
        //}

    }
}
