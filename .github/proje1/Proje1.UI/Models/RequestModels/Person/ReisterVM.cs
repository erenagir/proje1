namespace Proje1.UI.Models.RequestModels.Person
{
    public class ReisterVM
    {
        public int departmantId { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }
    }
}
