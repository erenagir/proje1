namespace Proje1.UI.Models.Dtos.Person
{
    public class TokenDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }

        public Roles Role { get; set; }
        public string Token { get; set; }
        public DateTime Expiredate { get; set; }
    }
}
