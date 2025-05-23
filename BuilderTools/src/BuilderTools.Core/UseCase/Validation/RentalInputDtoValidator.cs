using BuilderTools.Core.DTO;
using BuilderTools.Core.Model;
using BuilderTools.Core.Services;
using FluentValidation;

namespace BuilderTools.Core.UseCase.Validation
{
    public class RentalInputDtoValidator : AbstractValidator<RentalInputDto>
    {
        public RentalInputDtoValidator(IRentalRepository rentalRepository, IBuilderToolRepository builderToolRepository,
            IUserRepository userRepository)
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (id, cancellation) =>
                {
                    var exists = await userRepository.CheckIdUserAsync(id);
                    return exists;
                })
                .WithMessage("Nie istnieje user o tym Id");

            RuleFor(x => x.BuilderToolId)
                .MustAsync(async (id, cancellation) =>
                {
                    var exists = await builderToolRepository.CheckIdBuilderToolAsync(id);
                    return exists;
                })
                .WithMessage("Nie istnieje maszyna o tym Id");
            
            RuleFor(x => x.DataStart)
                .Must(startDate => startDate.Date > DateTime.UtcNow.Date)
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
