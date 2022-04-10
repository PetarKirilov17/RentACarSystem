using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public QueriesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: QueriesController
        public async Task<ActionResult> Index()
        {
           
            List<QueryIndexViewModel> model = await _context.Queries
                  .Select(item => new QueryIndexViewModel
                  {

                      Id = item.Id,
                      OwnerName = item.Owner.FirstName + " " + item.Owner.LastName,
                      CarName = item.Car.Brand + " " + item.Car.Model,
                      StartDate = item.StartDate,
                      EndDate = item.EndDate
                  }).ToListAsync();

            return View(model);
            // TO DO
        }

        // GET: QueriesController/Details/5
        public ActionResult Details(int id)
        {
            //Query query = _context.Queries.Find(id);

            //if (query == null)
            //{
            //    return NotFound();
            //}
            //Car car = _context.Cars.Find(query.CarId);
            //User user = _context.Users.Find(query.Owner);
            //var model = new QueryDetailsViewModel()
            //{
            //    Id = query.Id,
            //    StartDate = query.StartDate,
            //    EndDate = query.EndDate,
            //    Car = car.Brand + " " + car.Model,
            //    Year = car.Year,
            //    Seats = car.Seats,
            //    Description = car.Description,
            //    PricePerDay = car.PricePerDay,
            //    UserName = user.UserName,
            //    FullName = user.FirstName + " " + user.LastName,
            //    Phone = user.PhoneNumber,
            //    Email = user.Email
            //};

            return View();
        }

        // GET: QueriesController/ChooseDate
        public ActionResult ChooseDate()
        {
            return View(new ChooseDateViewModel());
        }

        // POST: QueriesController/ChooseDate
       /* [HttpPost]
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
        }*/

        // GET: QueriesController/Create
        public async Task<ActionResult> Create([FromQuery] ChooseDateViewModel dates)//list
        {
            List<Car> allCars = await _context.Cars.ToListAsync();
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
                        if (((query.StartDate < dates.StartDate && query.EndDate < dates.StartDate) && (query.StartDate > dates.EndDate && query.EndDate > dates.EndDate)))
                        {
                            availableCars.Add(item);
                        }
                    }
                }
            }
            List<CarForQueryViewModel> model = availableCars
                  .Select(item => new CarForQueryViewModel
                  {
                      Id = item.Id,
                      Brand = item.Brand,
                      Model = item.Model,
                      Year = item.Year,
                      Seats = item.Seats,
                      Description = item.Description,
                      PricePerDay = item.PricePerDay,
                      StartDate = dates.StartDate,
                      EndDate = dates.EndDate
                  }).ToList();
            return View(model);
        }
        
        public async Task<ActionResult> Hire(int id, DateTime StartDate, DateTime EndDate)
        {
            Query query = new Query
            {
                Owner = await _userManager.GetUserAsync(User),
                Car = _context.Cars.Find(id),
                StartDate = StartDate,
                EndDate = EndDate
            };

            await _context.Queries.AddAsync(query);
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
