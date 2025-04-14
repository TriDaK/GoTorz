using System.ComponentModel.DataAnnotations.Schema;

namespace Package_Api.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        // Foreign key for relations
        public int PackageId { get; set; }

        [InverseProperty("Pictures")]
        public Package Package { get; set; }
    }
}
