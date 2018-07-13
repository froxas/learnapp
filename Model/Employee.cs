using learnapp.Shared;

namespace learnapp.Model
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Function { get; set; }
        public string Department { get; set; }
        public Address Address { get; set; }
    }
}