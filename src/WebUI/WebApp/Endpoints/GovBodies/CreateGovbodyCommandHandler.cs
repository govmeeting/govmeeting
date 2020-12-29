using GM.Application.AppCore.Entities.Govbodies;
using GM.Infrastructure.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{

    public class CreateGovbodyCommandHandler : IRequestHandler<CreateGovbodyCommand, int?>
    {
        private readonly IApplicationDbContext _context;

        public CreateGovbodyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int?> Handle(CreateGovbodyCommand request, CancellationToken cancellationToken)
        {
            var entity = new Govbody(request.Name, request.ParentLocation, 0)
            {
                LongName = request.LongName
                //    InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
                //    {
                //        Item = i.Item,
                //        Quantity = i.Quantity,
                //        Rate = i.Rate
                //    }).ToList()
            };

            _context.Govbodies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
