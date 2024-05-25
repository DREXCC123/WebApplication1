using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

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

        [BindProperty]
        public SearchParameters? SearchParams { get; set; }


        public void OnGet(string? keyword = "", string? searchBy = "", string? sortBy = null, string? sortAsc = "true", int pageSize = 5, int pageIndex = 1)
        {
            if (SearchParams == null)
            {
                SearchParams = new SearchParameters()
                {
                    SortBy = sortBy,
                    SortAsc = sortAsc == "true",
                    SearchBy = searchBy,
                    Keyword = keyword,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
            
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


                if (!string.IsNullOrEmpty(SearchParams.SearchBy) && !string.IsNullOrEmpty(SearchParams.Keyword))
                {
                    if (SearchParams.SearchBy.ToLower() == "make")
                    {
                        Cars = Cars.Where(a => a.Make != null && a.Make.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                    }
                    else if (SearchParams.SearchBy.ToLower() == "model")
                    {
                        Cars = Cars.Where(a => a.Model != null && a.Model.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                    }
                    else if (SearchParams.SearchBy.ToLower() == "color")
                    {
                        Cars = Cars.Where(a => a.Color != null && a.Color.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                    }
                    else if (SearchParams.SearchBy.ToLower() == "year")
                    {
                        Cars = Cars.Where(a => a.Year.ToString().Contains(SearchParams.Keyword)).ToList();
                    }
                }
                else if ((string.IsNullOrEmpty(SearchParams.SearchBy) || SearchParams.SearchBy == "") && !string.IsNullOrEmpty(SearchParams.Keyword))
                {
                    Cars = Cars.Where(a => a.Make != null && a.Make.ToLower().Contains(SearchParams.Keyword.ToLower())).ToList();
                }

                if (SearchParams.SortBy == null || SearchParams.SortAsc == null)
                {
                    this.Cars = Cars;
                    goto page;
                }

                if (SearchParams.SortBy.ToLower() == "make" && SearchParams.SortAsc == true)
                {
                    this.Cars = Cars.OrderBy(a => a.Make).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "make" && SearchParams.SortAsc == false)
                {
                    this.Cars = Cars.OrderByDescending(a => a.Make).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "model" && SearchParams.SortAsc == true)
                {
                    this.Cars = Cars.OrderBy(a => a.Model).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "model" && SearchParams.SortAsc == false)
                {
                    this.Cars = Cars.OrderByDescending(a => a.Model).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "year" && SearchParams.SortAsc == true)
                {
                    this.Cars = Cars.OrderBy(a => a.Year).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "year" && SearchParams.SortAsc == false)
                {
                    this.Cars = Cars.OrderByDescending(a => a.Year).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "color" && SearchParams.SortAsc == true)
                {
                    this.Cars = Cars.OrderBy(a => a.Color).ToList();
                }
                else if (SearchParams.SortBy.ToLower() == "color" && SearchParams.SortAsc == false)
                {
                    this.Cars = Cars.OrderByDescending(a => a.Color).ToList();
                }
                else
                {
                    this.Cars = Cars;
                }
        page:
            //Paging
            int rem = this.Cars.Count % pageSize;
            float pageCount = (this.Cars.Count / pageSize) + (rem > 0 ? 1 : 0);
            int skip = (pageIndex <= pageCount ? pageSize * (pageIndex - 1) : pageSize * (Convert.ToInt32(pageCount - 1)));
            this.Cars = this.Cars.Skip(skip).Take(pageSize).ToList();
            SearchParams.SearchCount = this.Cars.Count;
            SearchParams.PageCount = Convert.ToInt32(pageCount);
        }

        public class Car
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Year { get; set; }
            public string Color { get; set; }
           
        }

        public class SearchParameters
        {
            public string? SearchBy { get; set; }
            public string? Keyword { get; set; } 
            public string? SortBy { get; set; }
            public bool? SortAsc { get; set; }
            public int? PageSize { get; set; }
            public int? PageIndex { get; set; }
            public int? PageCount { get; set; }
            public int? SearchCount { get; set; }
        }

    }
}