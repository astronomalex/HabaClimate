namespace HabaClimate.Data.Models
{
    public class AppUser
    {
        public int Id { get; set;}
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PassWordSalt { get; set; }
    }
}