using AppHistoryServer.Dtos.Interfaces;
using AppHistoryServer.Models.Variant;

namespace AppHistoryServer.Dtos.VariantDtos
{
    public class VariantDto : IDtoModel
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;

        public VariantDto(Variant variant)
        {
            if(variant.Content == null) throw new ArgumentNullException(nameof(variant.Content));
            
            Id = variant.Id;
            Content = variant.Content;
        }
    }
}
