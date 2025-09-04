namespace Slat.API.Server.DataModels
{
    public class LecturerDataModel
    {
      public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public DateTime DateCreated = DateTime.UtcNow;
    }
}
