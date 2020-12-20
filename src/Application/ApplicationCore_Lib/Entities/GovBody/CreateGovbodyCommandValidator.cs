using FluentValidation;
using FluentValidation.Validators;
using GM.ApplicationCore.Entities.Govbodies;
using GM.ApplicationCore.Entities.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GM.ApplicationCore.Entities.Govbodieses
{
    class CreateGovbodyCommandValidator : AbstractValidator<CreateGovbodyCommand>
    {
        public CreateGovbodyCommandValidator()
        {
            RuleFor(v => v.Name).NotNull();
            RuleFor(v => v.LongName).NotNull();
            RuleFor(v => v.ParentLocation).NotNull();
            // TODO - remove this check
            // NOTE: ScheduledMeetings is not required to be non-null.
            // This code is for experimenting with this type of validation.
            RuleFor(v => v.ScheduledMeetings).SetValidator(new MustHaveScheduledMeetingsPropertyValidator());

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
            var list = context.PropertyValue as IList<ScheduledMeetingVm>;
            return list != null && list.Any();
        }
    }
}
