namespace HealthCareSystem.BL.DTOs
{
    public class PatientReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public List<IssueReadDTO> Issues { get; set; } = new List<IssueReadDTO>();
    }
}
