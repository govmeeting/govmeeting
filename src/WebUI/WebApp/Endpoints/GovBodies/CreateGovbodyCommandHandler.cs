using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GM.Infrastructure.Data;
using GM.ApplicationCore.Entities.Govbodies;

namespace GM.WebApp.Endpoints.GovBodies
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
            var entity = new Govbody(request.Name, request.GovLocationId, 0)
            {
                LongName = request.LongName
                //    InvoiceItems = request.InvoiceItems.Select(i => new InvoiceItem
                //    {
                //        Item = i.Item,
                //        Quantity = i.Quantity,
                //        Rate = i.Rate
                //    }).ToList()
            };

            _context.GovBodies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }
    }
}
