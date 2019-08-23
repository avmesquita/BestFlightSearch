using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestFlightSearch.Solution.Domain.Validators
{
    public class AirportValidator : AbstractValidator<Airport>
    {
        public AirportValidator()
        {
            RuleFor(x => x.AirportCode)
                .NotEmpty()
                .WithMessage("ICAO Code must be exist");

            RuleFor(a => a.IATACode)
                .NotEmpty()
                .WithMessage("IATA Code must be exist");
        }
    }
}
