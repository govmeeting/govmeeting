using AutoMapper;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.DTOs.Govbodies;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{

    public class CreateGovbodyCommand : CreateGovbodyDto, IRequest<int?>
    {
    }

    public class CreateGovbodyCommandHandler : IRequestHandler<CreateGovbodyCommand, int?>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateGovbodyCommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int?> Handle(CreateGovbodyCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Govbody>(request);

            _context.Govbodies.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.Id;
        }

        //public CreateGovbodyCommandHandler() { }
        //public async Task<int?> Handle(CreateGovbodyCommand request, CancellationToken cancellationToken)
        //{
        //    Task task = Task.Delay(1);
        //    await task;
        //    return 1;
        //}
    }
}
