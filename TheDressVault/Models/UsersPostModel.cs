namespace TheDressVault.Models
{
    public class UsersPostModel
    {

        public string username { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }

        public string phone_number { get; set; }
    }
}
