namespace CustomerAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CustomerTypeId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string City { get; set; }    
        public string State { get; set; }
        public string Zip { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
