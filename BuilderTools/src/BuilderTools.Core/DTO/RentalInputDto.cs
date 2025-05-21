
using BuilderTools.Core.Model;

namespace BuilderTools.Core.DTO
{
    public class RentalInputDto
    {
        public Guid UserId { get; set; }
        public Guid BuilderToolId { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public decimal Amount { get; set; }
        public decimal Deposit { get; set; }
        public decimal? ExtraCost { get; set; }
        public string? Notes { get; set; }

        public RentalInputDto(Guid userId, Guid builderToolId, DateTime dataStart,
            DateTime dataEnd, decimal amount, decimal deposit, decimal? extraCost, string? notes)
        {
            UserId = userId;
            BuilderToolId = builderToolId;
            DataStart = dataStart;
            DataEnd = dataEnd;
            Amount = amount;
            Deposit = deposit;
            ExtraCost = extraCost;
            Notes = notes;
        }

        public Rental ToModel()
        {
            return new Rental(Guid.NewGuid(), UserId, BuilderToolId, DataStart, DataEnd, Amount, Deposit, ExtraCost, Notes);
        }
    }
}
