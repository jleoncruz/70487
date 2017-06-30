﻿using CountingKs.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountingKs.Models
{
    public class ModelFactory
    {
        public FoodModel Create(Food food)
        {
            return new FoodModel()
            {
                Description = food.Description,
                Measures = food.Measures.Select(m => Create(m))
            };
        }

        private MeasureModel Create(Measure measure)
        {
            return new MeasureModel()
            {
                Description = measure.Description,
                Calories = Math.Round(measure.Calories)
            };
        }
    }
}