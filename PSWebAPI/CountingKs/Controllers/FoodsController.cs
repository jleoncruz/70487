using CountingKs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CountingKs.Data.Entities;
using CountingKs.Models;
using System.Web.Http.Routing;
using CountingKs.Filters;

namespace CountingKs.Controllers
{
    //[RequireHttps]
    [CountingKsAuthorize(false)]
    public class FoodsController : BaseApiController
    {
        public FoodsController(ICountingKsRepository repo) : base(repo) // Interface, For Test. Decouple
        {
        }

        const int PAGE_SIZE = 50;

        //public IEnumerable<Food> Get()
        //public IEnumerable<object> Get()
        //public IEnumerable<FoodModel> Get(bool includeMeasures = true, int page = 0)
        public object Get(bool includeMeasures = true, int page = 0)
        {
            CountingKsRepository repository = new CountingKsRepository(new CountingKsContext());

            //Original
            //List<Food> results = repository.GetAllFoods()
            //    .OrderBy(f => f.Description)
            //    .Take(25)
            //    .ToList();

            //return results;

            IQueryable<Food> query;

            if (includeMeasures)
            {
                query = TheRepository.GetAllFoodsWithMeasures();
            }
            else
            {
                query = TheRepository.GetAllFoods();
            }

            var baseQuery = query.OrderBy(f => f.Description);

            var totalCount = baseQuery.Count();
            var totalPages = Math.Ceiling((double)totalCount / PAGE_SIZE);

            var helper = new UrlHelper(Request);
            var prevUrl = (page > 0) ? helper.Link("Food", new { page = page - 1 }) : "";
            var nextUrl = (page < totalPages - 1) ? helper.Link("Food", new { page = page + 1 }) : "";

            var results = baseQuery
                .Skip(PAGE_SIZE * page)
                .Take(PAGE_SIZE)
                .ToList()
                .Select(f => TheModelFactory.Create(f));

            return new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                PrevPageUrl = prevUrl,
                NextPageUrl = nextUrl,
                Results = results
            };
        }

        public FoodModel Get(int foodid)
        {
            return TheModelFactory.Create(TheRepository.GetFood(foodid));
        }
    }
}
