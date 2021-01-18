using FluentValidation;
using GM.Application.AppCore.Entities.GovLocations;
using GM.Application.DTOs.GovLocations;
using GM.Infrastructure.InfraCore.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterGovLocationCommand : GovLocation_Dto, IRequest<int?>
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public class RegisterGovLocationCommandHandler : 
        IRequestHandler<RegisterGovLocationCommand, int?>

    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public RegisterGovLocationCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<int?> Handle(RegisterGovLocationCommand request, CancellationToken cancellationToken)
        {
            //var entity = new GovLocation(request.Name, request.Type, request.Code);
            var entity = new GovLocation(request.Name, request.Type, null);

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

    public class CreateGovLocationValidator : AbstractValidator<RegisterGovLocationCommand>
    {
        public CreateGovLocationValidator()
        {
            RuleFor(v => v.Name).NotNull();

            //// TODO - remove this check
            //// NOTE: Govbodies is not required to be non-null.
            //// This code is for experimenting with this type of validation.
            //RuleFor(v => v.Govbodies).SetValidator(new MustHaveGovbodiesPropertyValidator());
        }
    }
    //public class MustHaveGovbodiesPropertyValidator : PropertyValidator
    //{
    //    public MustHaveGovbodiesPropertyValidator()
    //        : base("Property {PropertyName} should not be an empty list.")
    //    {
    //    }
    //    protected override bool IsValid(PropertyValidatorContext context)
    //    {
    //        return context.PropertyValue is IList<GovbodyDto> list && list.Any();
    //    }
    //}

}
