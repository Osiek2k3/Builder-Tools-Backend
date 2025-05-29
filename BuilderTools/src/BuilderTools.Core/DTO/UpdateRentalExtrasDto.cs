
namespace BuilderTools.Core.DTO
{
    public class UpdateRentalExtrasDto
    {
        public Guid RentalId { get; set; }
        public decimal? ExtraCost { get; set; }
        public string? Notes { get; set; }
    }
}
