using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.StudentName).NotEmpty().WithMessage("Must NOT be empty");
            RuleFor(x => x.ParentName).NotEmpty().WithMessage("Must NOT be empty");
            RuleFor(x => x.ParentId).NotEmpty().WithMessage("Must NOT be empty");
            //RuleFor(x => x.IsActive).NotEmpty().WithMessage("Must NOT be empty");
        }
    }
}
