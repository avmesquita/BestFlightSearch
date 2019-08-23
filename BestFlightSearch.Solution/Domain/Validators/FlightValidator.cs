using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace BestFlightSearch.Solution.Domain.Validators
{
    public class FlightValidator : AbstractValidator<Flight>
    {
        public FlightValidator()
        {
            RuleFor(x => x.AirportCode)
                .NotEmpty()
                .WithMessage("ICAO Code must be exist");

            RuleFor(a => a.IATACode)
                .NotEmpty()
                .WithMessage("IATA Code must be exist");

            RuleFor(a => a.FlightNumber)
                .NotEmpty()
                .WithMessage("Flight Number must be exist");

        }
    }
}
