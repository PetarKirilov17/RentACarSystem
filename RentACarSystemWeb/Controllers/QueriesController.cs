using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentACarSystemWeb.Data;
using RentACarSystemWeb.Models;
using RentACarSystemWeb.ViewModels.Cars;
using RentACarSystemWeb.ViewModels.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarSystemWeb.Controllers
{
    public class QueriesController : Controller
    {
        private DateTime startDate;
        private DateTime endDate;
        private readonly ApplicationDbContext _context;
        public QueriesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: QueriesController
        public async Task<ActionResult> Index()
        {
            
            List<QueryIndexViewModel> model = await _context.Queries
                  .Select(item => new QueryIndexViewModel
                  {
                      Id = item.Id,
                      OwnerName=item.Owner.FirstName +" "+ item.Owner.LastName,
                      CarName=item.Car.Brand+" "+item.Car.Model,
                      StartDate=item.StartDate,
                      EndDate=item.EndDate
                  }).ToListAsync();

            return View(model);
            // TO DO
        }

        // GET: QueriesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        // GET: QueriesController/ChooseDate
        public ActionResult ChooseDate()
        {
            return View();
        }

        // POST: QueriesController/ChooseDate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseDate([FromForm] ChooseDateViewModel model)
        {
            startDate = model.StartDate;
            endDate = model.EndDate;
            try
            {
                return RedirectToAction(nameof(Create));
            }
            catch
            {
                return View();
            }
        }

        // GET: QueriesController/Create
        public async Task<ActionResult> Create()
        {
            List<Car> allCars = _context.Cars.ToList();
            List<Car> availableCars = new List<Car>();
            foreach (var item in allCars)
            {
                if (item.CarQueries.Count == 0)
                {
                    availableCars.Add(item);
                }
                else
                {
                    foreach (var query in item.CarQueries)
                    {
                        if (((query.StartDate < startDate && query.EndDate < startDate) && (query.StartDate > endDate && query.EndDate > endDate)))
                        {
                            availableCars.Add(item);
                        }
                    }
                }
            }
            List<IndexViewModel> model = availableCars
                  .Select(item => new IndexViewModel
                  {
                      Id = item.Id,
                      Brand = item.Brand,
                      Model = item.Model,
                      Year = item.Year,
                      Seats = item.Seats,
                      Description = item.Description,
                      PricePerDay = item.PricePerDay
                  }).ToList();
            return View(model);
        }

        // POST: QueriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] IndexViewModel postModel)
        {
            Query query = new Query
            {
               // Owner=HttpContext.User
            };

            //await _context.Cars.AddAsync(car);
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

        // GET: QueriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: QueriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: QueriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QueriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
