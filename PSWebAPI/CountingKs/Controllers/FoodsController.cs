﻿using CountingKs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CountingKs.Data.Entities;

namespace CountingKs.Controllers
{
    public class FoodsController : ApiController
    {
        public IEnumerable<Food> Get()
        {
            CountingKsRepository repository = new CountingKsRepository(new CountingKsContext());

            List<Food> results = repository.GetAllFoods()
                .OrderBy(f => f.Description)
                .Take(25)
                .ToList();

            return results;
        }
    }
}