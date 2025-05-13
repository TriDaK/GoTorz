namespace Package_Api.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Package> Packages { get; set; }
    }
}
