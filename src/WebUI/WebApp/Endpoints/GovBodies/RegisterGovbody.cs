using AutoMapper;
using FluentValidation;
using FluentValidation.Validators;
using GM.Application.AppCore.Entities.Govbodies;
using GM.Application.DTOs.Govbodies;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{

    public class RegisterGovbody_Command : GovbodyDetails_Dto, IRequest<int?>
    {
    }

    public class RegisterGovbody_CommandHandler : IRequestHandler<RegisterGovbody_Command, int?>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RegisterGovbody_CommandHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int?> Handle(RegisterGovbody_Command request, CancellationToken cancellationToken)
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

    class RegisterGovbody_CommandValidator : AbstractValidator<RegisterGovbody_Command>
    {
        public RegisterGovbody_CommandValidator()
        {
            RuleFor(v => v.Name).NotNull();
            //RuleFor(v => v.ParentLocation).NotNull();

            //// TODO - remove this check
            //// NOTE: ScheduledMeetings is not required to be non-null.
            //// This code is for experimenting with this type of validation.
            //RuleFor(v => v.ScheduledMeetings).SetValidator(new MustHaveScheduledMeetingsPropertyValidator());

        }
    }

    public class MustHaveScheduledMeetingsPropertyValidator : PropertyValidator
    {
        public MustHaveScheduledMeetingsPropertyValidator()
            : base("Property {PropertyName} should not be an empty list.")
        {
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            return context.PropertyValue is IList<ScheduledMeeting_Dto> list && list.Any();
        }
    }

}
