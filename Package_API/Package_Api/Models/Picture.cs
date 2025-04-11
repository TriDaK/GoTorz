namespace Package_Api.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        // Foreign key for relations
        public string PackageId { get; set; }
    }
}
