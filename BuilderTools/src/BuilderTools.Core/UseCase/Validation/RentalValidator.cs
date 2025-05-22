using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using FluentValidation;

namespace BuilderTools.Core.UseCase.Validation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator(IRentalRepository rentalRepository)
        {
            RuleFor(x => x.RentalId)
                .MustAsync(async (id, cancellation) =>
                {
                    var exists = await rentalRepository.CheckIdRentalAsync(id);
                    return !exists;
                })
                .WithMessage("Ustawienie misji zakupowej o tym Id już istnieje");

            RuleFor(x => x.DataStart)
                .Must(startDate => startDate > DateTime.UtcNow)
                .WithMessage("Data startu musi być późniejsza niż data obecna");

            RuleFor(x => x.DataEnd)
                .Must((model, dataEnd) => dataEnd > model.DataStart)
                .WithMessage("Data końcowa musi być późniejsza niż data startu");

            RuleFor(x => x.DataEnd)
                .Must((model, dataEnd) => (dataEnd - model.DataStart).TotalDays <= 14)
                .WithMessage("Maszynę można wypożyczyć na maksymalnie 14 dni");

            RuleFor(x => x.DataEnd)
                .Must(dataEnd => dataEnd < DateTime.UtcNow.AddMonths(3))
                .WithMessage("Maszynę można wypożyczyć w okresie max do 3 miesiecy wprzód");
        }
    }
}
