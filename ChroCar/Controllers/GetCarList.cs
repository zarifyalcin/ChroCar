using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ChroCar.Models;

[ApiController]
[Route("api/get-car-list")] // Endpoint'in adı artık sabit
public class CarsController : ControllerBase
{
    private static readonly List<Car> _carList = new List<Car>
    {
        new Car { CarId = 1, Brand = "Honda", Model = "Civic", Year = 2022 },
        new Car { CarId = 2, Brand = "Ford", Model = "Focus", Year = 2021 },
        new Car { CarId = 3, Brand = "Toyota", Model = "Corolla", Year = 2023 }
    };

    [HttpGet] // GET api/get-car-list?id=...
    public ActionResult<IEnumerable<Car>> GetCars([FromQuery] int? id)
    {
        if (id.HasValue)
        {
            var car = _carList.FirstOrDefault(c => c.CarId == id.Value);

            if (car == null)
            {
                return NotFound();
            }

            return Ok(new List<Car> { car });
        }

        return Ok(_carList);
    }
}