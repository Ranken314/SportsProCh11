namespace SportsPro.Models.ViewModels
{
    public class TechIncidentViewModel
    {
        public Technician? Technician { get; set; }
        public Incident? Incident { get; set; }  
        public IEnumerable<Incident>? Incidents { get; set; }
    }
}
