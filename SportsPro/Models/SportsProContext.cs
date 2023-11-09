using Microsoft.EntityFrameworkCore;

namespace SportsPro.Models
{
    public class SportsProContext : DbContext
    {
        public SportsProContext(DbContextOptions<SportsProContext> options)
    : base(options)
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    ProductCode = "DRAFT10",
                    ProductName = "Draft Manager 1.0",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2017-02-01")
                },
                new Product
                {
                    ProductID = 2,
                    ProductCode = "DRAFT20",
                    ProductName = "Draft Manager 2.0",
                    YearlyPrice = 5.99M,
                    ReleaseDate = DateTime.Parse("2019-07-15 00:00:00.000")
                },
                new Product
                {
                    ProductID = 3,
                    ProductCode = "LEAG10",
                    ProductName  = "League Scheduler 1.0",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2016-05-01 00:00:00.000")
                },
                new Product
                {
                    ProductID = 4,
                    ProductCode = "LEAGD10",
                    ProductName = "League Scheduler Deluxe 1.0",
                    YearlyPrice = 7.99M,
                    ReleaseDate = DateTime.Parse("2016-08-01 00:00:00.000")
                },
                new Product
                {
                    ProductID = 5,
                    ProductCode = "TEAM10",
                    ProductName = "Team Manager 1.0",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2017-05-01 00:00:00.000")
                },
                new Product
                {
                    ProductID = 6,
                    ProductCode = "TRNY10",
                    ProductName = "Tournament Master 1.0",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2015-12-01 00:00:00.000")
                },
                new Product
                {
                    ProductID = 7,
                    ProductCode = "TRNY20",
                    ProductName = "Tournament Master 2.0",
                    YearlyPrice = 5.99M,
                    ReleaseDate = DateTime.Parse("2018-02-15 00:00:00.000")
                }
            );

            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianID = 11,
                    TechnicianName = "Alison Diaz",
                    TechnicianEmail = "alison@sportsprosoftware.com",
                    TechnicianPhone = "800-555-0443"
                },
                new Technician
                {
                    TechnicianID = 12,
                    TechnicianName = "Jason Lee",
                    TechnicianEmail = "jason@sportsprosoftware.com",
                    TechnicianPhone = "800-555-0444"
                },
                new Technician
                {
                    TechnicianID = 13,
                    TechnicianName = "Andrew Wilson",
                    TechnicianEmail = "awilson@sportsprosoftware.com",
                    TechnicianPhone = "800-555-0449"
                },
                new Technician
                {
                    TechnicianID = 14,
                    TechnicianName = "Gunter Wendt",
                    TechnicianEmail = "gunter@sportsprosoftware.com",
                    TechnicianPhone = "800-555-0400"
                },
                new Technician
                {
                    TechnicianID = 15,
                    TechnicianName = "Gina Fiori",
                    TechnicianEmail = "gfiori@sportsprosoftware.com",
                    TechnicianPhone = "800-555-0459"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = "AU", CountryName = "Australia" },
                new Country { CountryID = "AT", CountryName = "Austria" },
                new Country { CountryID = "BE", CountryName = "Belgium" },
                new Country { CountryID = "BR", CountryName = "Brazil" },
                new Country { CountryID = "CA", CountryName = "Canada" },
                new Country { CountryID = "CN", CountryName = "China" },
                new Country { CountryID = "DK", CountryName = "Denmark" },
                new Country { CountryID = "FI", CountryName = "Finland" },
                new Country { CountryID = "FR", CountryName = "France" },
                new Country { CountryID = "GR", CountryName  = "Greece" },
                new Country { CountryID = "GL", CountryName = "Greenland" },
                new Country { CountryID = "HK", CountryName = "Hong Kong" },
                new Country { CountryID = "IS", CountryName = "Iceland" },
                new Country { CountryID = "IN", CountryName = "India" },
                new Country { CountryID = "IE", CountryName = "Ireland" },
                new Country { CountryID = "IL", CountryName = "Israel" },
                new Country { CountryID = "IT", CountryName = "Italy" },
                new Country { CountryID = "JP", CountryName = "Japan" },
                new Country { CountryID = "LR", CountryName = "Liberia" },
                new Country { CountryID = "MY", CountryName = "Malaysia" },
                new Country { CountryID = "MX", CountryName = "Mexico" },
                new Country { CountryID = "NL", CountryName = "Netherlands" },
                new Country { CountryID = "NZ", CountryName = "New Zealand" },
                new Country { CountryID = "NG", CountryName = "Nigeria" },
                new Country { CountryID = "PH", CountryName  = "Philippines" },
                new Country { CountryID = "PT", CountryName = "Portugal" },
                new Country { CountryID = "PR", CountryName = "Puerto Rico" },
                new Country { CountryID = "QA", CountryName = "Qatar" },
                new Country { CountryID = "SG", CountryName = "Singapore" },
                new Country { CountryID = "ES", CountryName = "Spain" },
                new Country { CountryID = "SE", CountryName = "Sweden" },
                new Country { CountryID = "CH", CountryName = "Switzerland" },
                new Country { CountryID = "TH", CountryName = "Thailand" },
                new Country { CountryID = "TR", CountryName = "Turkey" },
                new Country { CountryID = "UA", CountryName = "Ukraine" },
                new Country { CountryID = "AE", CountryName = "United Arab Emirates" },
                new Country { CountryID = "GB", CountryName = "United Kingdom" },
                new Country { CountryID = "US", CountryName = "United States" },
                new Country { CountryID = "VN", CountryName = "Vietnam" },
                new Country { CountryID = "ZW", CountryName = "Zimbabwe" }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerID = 1002,
                    FirstName = "Ania",
                    LastName = "Irvin",
                    Address = "PO Box 96621",
                    City = "Washington",
                    State = "DC",
                    PostalCode = "20090",
                    CountryID = "US",
                    Phone = "(301) 555-8950",
                    Email = "ania@mma.nidc.com"
                },
                new Customer
                {
                    CustomerID = 1004,
                    FirstName = "Kenzie",
                    LastName = "Quinn",
                    Address = "1990 Westwood Blvd Ste 260",
                    City = "Los Angeles",
                    State = "CA",
                    PostalCode = "90025",
                    CountryID = "US",
                    Phone = "(800) 555-8725",
                    Email = "kenzie@mma.jobtrak.com"
                },
                new Customer
                {
                    CustomerID = 1006,
                    FirstName = "Anton",
                    LastName = "Mauro",
                    Address = "3255 Ramos Cir",
                    City = "Sacramento",
                    State = "CA",
                    PostalCode = "95827",
                    CountryID = "US",
                    Phone = "(916) 555-6670",
                    Email = "amauro@yahoo.org"
                },
                new Customer
                {
                    CustomerID = 1008,
                    FirstName = "Kaitlyn",
                    LastName = "Anthoni",
                    Address = "Box 52001",
                    City = "San Francisco",
                    State = "CA",
                    PostalCode = "94152",
                    CountryID = "US",
                    Phone = "(800) 555-6081",
                    Email = "kanthoni@pge.com"
                },
                new Customer
                {
                    CustomerID = 1010,
                    FirstName = "Kendall",
                    LastName = "Mayte",
                    Address = "PO Box 2069",
                    City = "Fresno",
                    State = "CA",
                    PostalCode = "93718",
                    CountryID = "US",
                    Phone = "(559) 555-9999",
                    Email = "kmayte@fresno.ca.gov"
                },
                new Customer
                {
                    CustomerID = 1012,
                    FirstName = "Marvin",
                    LastName = "Quintin",
                    Address = "4420 N. First Street, Suite 108",
                    City = "Fresno",
                    State = "CA",
                    PostalCode = "93726",
                    CountryID = "US",
                    Phone = "(559) 555-9586",
                    Email = "marvin@expedata.com"
                },
                new Customer
                {
                    CustomerID = 1015,
                    FirstName = "Gonzalo",
                    LastName = "Keeton",
                    Address = "27371 Valderas",
                    City = "Mission Viejo",
                    State = "CA",
                    PostalCode = "92691",
                    CountryID = "US",
                    Phone = "(214) 555-3647",
                    Email = ""
                }
            );


            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentID = 1,
                    CustomerID = 1010,
                    ProductID = 1,
                    TechnicianID = 11,
                    Title = "Could not install",
                    Description = "Media appears to be bad.",
                    DateOpened = DateTime.Parse("2020-01-08"),
                    DateClosed = DateTime.Parse("2020-01-10")
                },
                new Incident
                {
                    IncidentID = 2,
                    CustomerID = 1002,
                    ProductID = 4,
                    TechnicianID = 14,
                    Title = "Error importing data",
                    Description = "Received error message 415 while trying to import data from previous version.",
                    DateOpened = DateTime.Parse("2020-01-09"),
                    DateClosed = null
                },
                new Incident
                {
                    IncidentID = 3,
                    CustomerID = 1015,
                    ProductID = 6,
                    TechnicianID = 15,
                    Title = "Could not install",
                    Description = "Setup failed with code 104.",
                    DateOpened = DateTime.Parse("2020-01-08"),
                    DateClosed = DateTime.Parse("2020-01-10")
                },
                new Incident
                {
                    IncidentID = 4,
                    CustomerID = 1010,
                    ProductID = 3,
                    TechnicianID = null,
                    Title = "Error launching program",
                    Description = "Program fails with error code 510, unable to open database.",
                    DateOpened = DateTime.Parse("2020-01-10"),
                    DateClosed = null
                }
            );

            /***************************************************************
             *  many-to-many relationship for Registrations table
             **************************************************************/

            // composite primary key
            modelBuilder.Entity<Registration>()
                .HasKey(r => new { r.CustomerID, r.ProductID });

            // one-to-many relationship
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Registrations)
                .HasForeignKey(r => r.CustomerID);

            // one-to-many relationship between Author and BookAuthor
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Registrations)
                .HasForeignKey(r => r.ProductID);

            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    CustomerID = 1002,
                    ProductID = 1
                },
                new Registration
                {
                    CustomerID = 1002,
                    ProductID = 3
                },
                new Registration
                {
                    CustomerID = 1010,
                    ProductID = 2
                }
            );
        }
    }
}
