﻿using Microsoft.AspNetCore.Mvc;
using Pgs.Kanban.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pgs.Kanban.Api.Controllers
{
    [Route("api/[controller]")]  //adnotacja - odcina slowo controller zostaje : http://localhost:54820/api/RandomGeneration/

    public class RandomGeneratorController : Controller
    {
        private RandomGeneratorService randomGeneratorService;

        public RandomGeneratorController()
        {
            randomGeneratorService = new RandomGeneratorService();
        }

        [HttpGet]
        public IActionResult GetRandomNumber()
        {
            var number = randomGeneratorService.GenerateRandomNumber();
            return Ok(number);
        }

        [HttpGet]
        [Route("{maxValue}")]
        public IActionResult GetRandomNumberInRange(int maxValue)
        {
            var number = randomGeneratorService.GenerateRandomNumber(maxValue);
            return Ok(number);
        }

        [HttpPost]
        public IActionResult AddNumber([FromBody]int number)
        {
            randomGeneratorService.AddNumberToList(number);
            return NoContent();
        }

        [HttpDelete]
        //[Route("{number}")]
        public IActionResult DeleteNumber([FromBody]int number)
        {
            //w ciele wpisujemy liczbę do usunięcia, a nie jej pozycję w tablicy.
            randomGeneratorService.DeleteNumber(number);
            return NoContent();  //status 204
        }

        [HttpDelete]
        [Route("DeleteId/{number}")]
        public IActionResult DeleteNumber2(int number)
        {
            //w adresie wpisujemy liczbę do usunięcia - jej pozycję w liście (Pierwszy element oczywiscie 0)
            randomGeneratorService.DeleteNumber2(number);
            return NoContent();
        }

        [HttpGet]
        [Route("AllNumbers")]
        public IActionResult GetAllNumbers()
        {
            var numbers = randomGeneratorService.GetNumberList();
            return Ok(numbers);
        }
    }
}
