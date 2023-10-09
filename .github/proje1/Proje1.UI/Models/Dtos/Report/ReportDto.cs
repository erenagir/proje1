using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje1.UI.Models.Dtos.Report
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string DepartmentName { get; set; }

        public string detail { get; set; }
        public DateTime Date { get; set; }
    }
}
