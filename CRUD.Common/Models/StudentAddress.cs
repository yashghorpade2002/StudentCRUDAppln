namespace CRUD.Common.Models
{
    public class StudentAddress
    {
        public int AddressId {  get; set; }

        public string Streetname { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;
        
        public string state { get; set; } = string.Empty;

        public int Pincode { get; set; }
    }
}