﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BusinessRulesEngineApp
{
    public class Program
    {
        public static void Main()
        {
            List<Rule> rules = new List<Rule>
            {
                // Create some rules using LINQ.ExpressionTypes for the comparison operators
                new Rule("Year", ExpressionType.GreaterThan, "2012"),
                new Rule("Make", ExpressionType.Equal, "El Diablo"),
                new Rule("Model", ExpressionType.Equal, "Torch")
            };
            var compiledMakeModelYearRules = PrecompiledRules.CompileRule<ICar>(rules);

            // Create a list to house your test cars
            List<ICar> cars = new List<ICar>();

            // Create a car that's year and model fail the rules validations      
            Car car1_Bad = new Car
            {
                Year = 2011,
                Make = "El Diablo",
                Model = "Torche"
            };

            // Create a car that meets all the conditions of the rules validations
            Car car2_Good = new Car
            {
                Year = 2015,
                Make = "El Diablo",
                Model = "Torch"
            };

            // Add your cars to the list
            cars.Add(car1_Bad);
            cars.Add(car2_Good);

            // Iterate through your list of cars to see which ones meet the rules vs. the ones that don't
            cars.ForEach(car =>
            {
                Console.WriteLine(compiledMakeModelYearRules.All(rule => rule(car))
                    ? "Car model: {0} Passed the compiled rules engine check!"
                    : "Car model: {0} Failed the compiled rules engine check!", car.Model);
            });
        }
    }
}
