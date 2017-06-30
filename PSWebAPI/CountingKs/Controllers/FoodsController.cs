using CountingKs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CountingKs.Data.Entities;
using CountingKs.Models;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        ICountingKsRepository _repo;
        ModelFactory _modelFactory;

        public FoodsController(ICountingKsRepository repo) // Interface, For Test. Decouple
        {
            _repo = repo;
            _modelFactory = new ModelFactory();
        }

        //public IEnumerable<Food> Get()
        //public IEnumerable<object> Get()
        public IEnumerable<FoodModel> Get()
        {
            CountingKsRepository repository = new CountingKsRepository(new CountingKsContext());

            //Original
            //List<Food> results = repository.GetAllFoods()
            //    .OrderBy(f => f.Description)
            //    .Take(25)
            //    .ToList();

            //return results;

            var results = repository.GetAllFoodsWithMeasures()
                .OrderBy(f => f.Description)
                .Take(25)
                .ToList()
                .Select(f => _modelFactory.Create(f));

            return results;
        }

        public FoodModel Get(int id)
        {
            return _modelFactory.Create(_repo.GetFood(id));
        }
    }
}
