﻿
using BuilderTools.Core.DTO;

namespace BuilderTools.Core.Model
{
    public class Rental
    {
        public Guid RentalId { get; set; }
        public Guid UserId { get; set; }
        public Guid BuilderToolId { get; set; }
        public DateTime DataStart { get; set; }
        public DateTime DataEnd { get; set; }
        public decimal Amount { get; set; }
        public decimal Deposit { get; set; }
        public decimal? ExtraCost { get; set; }
        public string? Notes { get; set; }

        public Rental(Guid rentalId, Guid userId, Guid builderToolId, DateTime dataStart,
            DateTime dataEnd, decimal amount, decimal deposit, decimal? extraCost, string? notes)
        {
            RentalId = rentalId;
            UserId = userId;
            BuilderToolId = builderToolId;
            DataStart = dataStart;
            DataEnd = dataEnd;
            Amount = amount;
            Deposit = deposit;
            ExtraCost = extraCost;
            Notes = notes;
        }

        public RentalDto ToModel()
        {
            return new RentalDto(RentalId, UserId, BuilderToolId, DataStart, DataEnd, Amount, Deposit, ExtraCost, Notes);
        }
    }
}
