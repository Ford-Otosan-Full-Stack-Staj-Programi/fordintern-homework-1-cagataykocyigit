using FluentValidation;
using Homework1.Data.Model;

namespace Homework1.Web.Validators
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id is invalid.");


            RuleFor(x => x.FirstName)
                .MinimumLength(10)
                .WithMessage("The 'Name' should have at least 10 characters.")
                .MaximumLength(40)
                .WithMessage("The 'Name' should have not more than 40 characters.");


            RuleFor(x => x.Email)
                .EmailAddress();


        }

    }
}
