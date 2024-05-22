using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 

namespace WebApplicationDrexlerMacaspac.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<Car> Cars { get; set; }


        public void OnGet(string? sortBy = null, string? sortAsc = "true")
        {
            List<Car>? Cars = new List<Car>()
            {
                new Car () { 
                    Make = "Toyota", 
                    Model = "Camry", 
                    Year = 2022, 
                    Color = "Red" },

                new Car () { 
                    Make = "Honda", 
                    Model = "Civic", 
                    Year = 2021, 
                    Color = "Black" },

                new Car () { 
                    Make = "Ford", 
                    Model = "Mustang", 
                    Year = 2020, 
                    Color = "Blue" },

                new Car () { 
                    Make = "Chevrolet", 
                    Model = "Corvette", 
                    Year = 2019, 
                    Color = "Yellow" },

                new Car () { 
                    Make = "BMW", 
                    Model = "3 Series", 
                    Year = 2018, 
                    Color = "White" },

                new Car () { 
                    Make = "Mercedes-Benz", 
                    Model = "C-Class", 
                    Year = 2017, 
                    Color = "Silver" },

                new Car () { 
                    Make = "Audi",
                    Model = "A4", 
                    Year = 2016, 
                    Color = "Gray" },

                new Car () { 
                    Make = "Nissan", 
                    Model = "Altima", 
                    Year = 2015, 
                    Color = "Burgundy" },

                new Car () { 
                    Make = "Subaru",
                    Model = "Outback", 
                    Year = 2014,
                    Color = "Green" },

                new Car () { 
                    Make = "Hyundai",
                    Model = "Sonata",
                    Year = 2013,
                    Color = "Blue" },

                new Car () { 
                    Make = "Kia",
                    Model = "Optima", 
                    Year = 2012,
                    Color = "Red" },

                new Car () { 
                    Make = "Volkswagen", 
                    Model = "Jetta",
                    Year = 2011, 
                    Color = "Black" },

                new Car () { 
                    Make = "Mazda", 
                    Model = "3", 
                    Year = 2010,
                    Color = "Blue" },

                new Car () {
                    Make = "Lexus", 
                    Model = "IS",
                    Year = 2009, 
                    Color = "White" },

                new Car () { 
                    Make = "Acura", 
                    Model = "TL", 
                    Year = 2008, 
                    Color = "Gray" }
            };


            if (sortBy == null || sortAsc == null)
            { 
                this.Cars = Cars; 
                return; }

            if (sortBy!.ToLower() == "make" && sortAsc!.ToLower() == "true")
            { 
                this.Cars = Cars.OrderBy(a => a.Make).ToList(); }
            else if (sortBy!.ToLower() == "make" && sortAsc!.ToLower() == "false")
            { 
                this.Cars = Cars.OrderByDescending(a => a.Make).ToList(); }
            else if (sortBy!.ToLower() == "model" && sortAsc!.ToLower() == "true")
            { 
                this.Cars = Cars.OrderBy(a => a.Model).ToList(); }
            else if (sortBy!.ToLower() == "model" && sortAsc!.ToLower() == "false")
            {
                this.Cars = Cars.OrderByDescending(a => a.Model).ToList(); }
            else if (sortBy!.ToLower() == "year" && sortAsc!.ToLower() == "true")
            {
                this.Cars = Cars.OrderBy(a => a.Year).ToList(); }
            else if (sortBy!.ToLower() == "year" && sortAsc!.ToLower() == "false")
            { 
                this.Cars = Cars.OrderByDescending(a => a.Year).ToList(); }
            else if (sortBy!.ToLower() == "color" && sortAsc!.ToLower() == "true")
            { 
                this.Cars = Cars.OrderBy(a => a.Color).ToList(); }
            else if (sortBy!.ToLower() == "color" && sortAsc!.ToLower() == "false")
            { 
                this.Cars = Cars.OrderByDescending(a => a.Color).ToList();
            }
            else 
            { 
                this.Cars = Cars;
            }
        }

        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }
        }
    }
}
