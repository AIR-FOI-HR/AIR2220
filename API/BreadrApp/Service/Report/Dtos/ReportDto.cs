
namespace Service.Report.Dtos
{
    public class ReportDto
    {
        public int ReportId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }

        public string GateName { get; set; }
    }
}
