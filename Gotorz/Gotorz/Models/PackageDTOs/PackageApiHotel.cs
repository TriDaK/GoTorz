using System.Text.Json.Serialization;

namespace Gotorz.Models.PackageDTOs
{
    public class PackageApiHotel
    {
        [JsonPropertyName("phone")]
        public string Phone { get; set; }

    }
}

