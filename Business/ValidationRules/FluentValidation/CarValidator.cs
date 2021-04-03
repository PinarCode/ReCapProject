using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(100).When(b=>b.BrandId==1);

            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(3);
        }
    }
}
