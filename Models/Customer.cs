namespace ShopManagerMini.Models
{
    public class Customer
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }

        public Customer() { }

        public Customer(string id, string fullName, string phone, string type)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            Type = type;
        }
    }
}
