﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

/*
 * References:
 * - https://www.psclistens.com/insight/blog/quickly-build-a-business-rules-engine-using-c-and-lambda-expression-trees/
 * 
 * */

namespace BusinessRulesEngineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Rule> rules = new List<Rule> 
            {
                // Create some rules using LINQ.ExpressionTypes for the comparison operators
                new Rule("Year", ExpressionType.GreaterThan, "2012"),
                new Rule("Make", ExpressionType.Equal, "El Diablo"),
                new Rule("Model", ExpressionType.Equal, "Torch" )
            };

            var compiledMakeModelYearRules = PrecompiledRules.CompileRule(new List<ICar>(), rules);

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
                Console.WriteLine(
                    compiledMakeModelYearRules.TakeWhile(rule => rule(car)).Any()
                        ? "Car model: {0} Passed the compiled rules engine check!"
                        : "Car model: {0} Failed the compiled rules engine check!", car.Model);
            });


            Console.WriteLine(string.Empty);
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();

        }
    }
}
