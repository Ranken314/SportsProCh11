namespace SportsPro.Models
{
    public interface ISportsProUnit
    {
        Repository<Product> Products { get; }
        Repository<Technician> Technicians { get; }
        Repository<Customer> Customers { get; }
        Repository<Country> Countries { get; }
        Repository<Registration> Registrations { get; }
        Repository<Incident> Incidents { get; }

        void Save();
    }
}
