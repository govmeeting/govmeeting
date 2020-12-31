using FluentValidation;
using FluentValidation.Validators;
using GM.Application.DTOs.Govbodies;
using System.Collections.Generic;
using System.Linq;

namespace GM.WebUI.WebApp.Endpoints.Govbodies
{
    class CreateGovbodyCommandValidator : AbstractValidator<CreateGovbodyCommand>
    {
        public CreateGovbodyCommandValidator()
        {
            RuleFor(v => v.Name).NotNull();
            RuleFor(v => v.LongName).NotNull();
            RuleFor(v => v.ParentLocation).NotNull();

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
            return context.PropertyValue is IList<ScheduledMeetingDto> list && list.Any();
        }
    }
}
