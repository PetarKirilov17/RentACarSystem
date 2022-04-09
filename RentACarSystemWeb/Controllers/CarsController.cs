using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarSystemWeb.Data;
using RentACarSystemWeb.Models;
using RentACarSystemWeb.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.Controllers
{

    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: CarsController
        public async Task<ActionResult> Index()
        {
            List<IndexViewModel> model = await _context.Cars
                  .Select(item => new IndexViewModel
                  {
                      Id = item.Id,
                      Brand = item.Brand,
                      Model = item.Model,
                      Year = item.Year,
                      Seats = item.Seats,
                      Description = item.Description,
                      PricePerDay = item.PricePerDay
                  }).ToListAsync();

            return View(model);
        }

        // GET: CarsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Car car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var model = new DetailsViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Seats = car.Seats,
                Description = car.Description,
                PricePerDay = car.PricePerDay
            };
            return View(model);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([FromForm] CreateViewModel postModel)
        {
            Car car = new Car
            {
                Brand = postModel.Brand,
                Model = postModel.Model,
                Year = postModel.Year,
                Seats = postModel.Seats,
                Description = postModel.Description,
                PricePerDay = postModel.PricePerDay
            };

            await _context.Cars.AddAsync(car);
            bool created = _context.SaveChanges() != 0;
            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Car car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var model = new EditViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Seats = car.Seats,
                Description = car.Description,
                PricePerDay = car.PricePerDay
            };
            return View(model);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [FromForm] EditViewModel postModel)
        {
            Car car = new Car
            {
                Id = id,
                Brand = postModel.Brand,
                Model = postModel.Model,
                Year = postModel.Year,
                Seats = postModel.Seats,
                Description = postModel.Description,
                PricePerDay = postModel.PricePerDay
            };

            _context.Cars.Update(car);
            bool updated = await _context.SaveChangesAsync() != 0;
            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Car car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var model = new DeleteViewModel()
            {
                Id = car.Id,
                Brand = car.Brand,
                Model = car.Model,
                Year = car.Year,
                Seats = car.Seats,
                Description = car.Description,
                PricePerDay = car.PricePerDay
            };
            return View(model);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            Car car = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(car);
            bool deleted = await _context.SaveChangesAsync()!=0;
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
