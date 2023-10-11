namespace Proje1.UI.Models.Dtos.Person
{
    public class TokenDto
    {
        public Roles Role { get; set; }
        public string Token { get; set; }
        public DateTime Expiredate { get; set; }
    }
}
