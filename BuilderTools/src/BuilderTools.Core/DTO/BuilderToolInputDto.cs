
using BuilderTools.Core.Model;
using Microsoft.AspNetCore.Http;

namespace BuilderTools.Core.DTO
{
    public class BuilderToolInputDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public decimal PricePerDay { get; set; }
        public IFormFile Image { get; set; }

        public BuilderToolInputDto() { }
        public BuilderToolInputDto(Guid categoryId, string name, string permission, decimal pricePerDay, IFormFile image)
        {
            CategoryId = categoryId;
            Name = name;
            Permission = permission;
            PricePerDay = pricePerDay;
            Image = image;
        }

        public BuilderTool ToModel()
        {
            byte[] imageBytes = null;
            if (Image != null)
            {
                using var ms = new MemoryStream();
                Image.CopyTo(ms);
                imageBytes = ms.ToArray();
            }
            return new BuilderTool(Guid.NewGuid(), CategoryId, Name, Permission, PricePerDay, imageBytes);
        }
    }
}
