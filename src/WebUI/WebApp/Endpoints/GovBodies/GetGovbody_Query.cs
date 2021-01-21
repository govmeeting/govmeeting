using AutoMapper;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.DTOs.Govbodies;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    public class GetGovbody_Query : IRequest<GovbodyDetails_Dto>
    {
        public int GovbodyId { get; set; }
    }
    public class GetGovbody_QueryHandler : IRequestHandler<GetGovbody_Query, GovbodyDetails_Dto>
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public GetGovbody_QueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GovbodyDetails_Dto> Handle(GetGovbody_Query request, CancellationToken cancellationToken)
        {
            var result = new GovbodyDetails_Dto();

            Govbody govbody = await _context.Govbodies
                .Where(l => l.Id == request.GovbodyId)
                .Include(l => l.ElectedOfficials)
                .Include(l => l.AppointedOfficials)
                .FirstOrDefaultAsync();

            if (govbody == null) return null;

            result = _mapper.Map<GovbodyDetails_Dto>(govbody);

            return result;
        }

    }
}
