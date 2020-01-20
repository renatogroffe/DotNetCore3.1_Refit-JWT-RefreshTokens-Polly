namespace CargaProdutos.Models
{
    public class AccessCredentials
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string GrantType { get; set; }
    }
}