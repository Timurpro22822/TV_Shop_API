using BusinessLogic.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Validators
{
    public class TvValidators : AbstractValidator<TVDto>
    {
        public TvValidators()
        {
            int t = DateTime.Now.Year;
            RuleFor(x => x.Model)
                .NotNull()
                .NotEmpty()
                .Length(5, 67);

            RuleFor(x => x.Year)
                .NotNull()
                .NotEmpty()
                .LessThanOrEqualTo(t);

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);

            RuleFor(x => x.ImagePath)
                .Must(LinkMustBeAUri).WithMessage("Link '{PropertyValue}' must be a valid URI.");
        }

        private static bool LinkMustBeAUri(string link)
        {
            if (string.IsNullOrWhiteSpace(link)) return false;

            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
