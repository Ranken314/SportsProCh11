namespace SportsPro.Models
{
    public class SportsProUnit : ISportsProUnit
    {
        private SportsProContext context { get; set; }
        public SportsProUnit(SportsProContext ctx) => context = ctx;

        private Repository<Product> productRepo;
        public Repository<Product> Products
        {
            get
            {
                if (productRepo == null)
                    productRepo = new Repository<Product>(context);
                return productRepo;
            }
        }

        private Repository<Technician> techRepo;
        public Repository<Technician> Technicians
        {
            get
            {
                if (techRepo == null)
                    techRepo = new Repository<Technician>(context);
                return techRepo;
            }
        }

        private Repository<Customer> customerRepo;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerRepo == null)
                    customerRepo = new Repository<Customer>(context);
                return customerRepo;
            }
        }

        private Repository<Country> countryRepo;
        public Repository<Country> Countries
        {
            get
            {
                if (countryRepo == null)
                    countryRepo = new Repository<Country>(context);
                return countryRepo;
            }
        }

        private Repository<Incident> incidentRepo;
        public Repository<Incident> Incidents
        {
            get
            {
                if (incidentRepo == null)
                    incidentRepo = new Repository<Incident>(context);
                return incidentRepo;
            }
        }

        private Repository<Registration> registrationRepo;
        public Repository<Registration> Registrations
        {
            get
            {
                if (registrationRepo == null)
                    registrationRepo = new Repository<Registration>(context);
                return registrationRepo;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
