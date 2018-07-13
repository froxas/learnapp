using learnapp.Shared;

namespace learnapp.Model
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string House { get; set; }
        public string City { get; set; }
    }
}