using FluentValidation;

namespace GM.WebUI.WebApp.Endpoints.GovLocations
{
    public class CreateGovLocationCommandVaildator : AbstractValidator<CreateGovLocationCommand>
    {
        public CreateGovLocationCommandVaildator()
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