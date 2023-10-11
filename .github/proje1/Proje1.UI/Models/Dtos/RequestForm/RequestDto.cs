namespace Proje1.UI.Models.Dtos.RequestForm
{
    public class RequestDto
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string Products { get; set; }
        public Status Status { get; set; }
    }
}
