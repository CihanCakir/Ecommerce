namespace Core.Entities.OrderAggregate
{
    public class Address
    {
        public Address()
        {
        }

        public Address(string firstName, string lastName, string iL, string ilce, string description, string state, string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            IL = iL;
            Ilce = ilce;
            Description = description;
            State = state;
            ZipCode = zipCode;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IL { get; set; }
        public string Ilce { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}