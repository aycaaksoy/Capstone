using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<Announcement>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Must NOT be empty");
            RuleFor(x => x.Body).NotEmpty().WithMessage("Must NOT be empty");
            RuleFor(x => x.TimePosted).NotEmpty().WithMessage("Must NOT be empty");

        }
    }
}
