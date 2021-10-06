using hotel_booking_model;
using hotel_booking_services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel_booking_mvc.Controllers
{
    public class AdminDashboardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TransactionPeriod transactionPeriod = new TransactionPeriod();
            //ViewData["transactionPeriod"] = transactionPeriod;
            return View(transactionPeriod);
        }
    }
}

//private readonly IBook _adminBook;
//private readonly IUser _adminUser;
//private readonly IMainCategory _category;
//private readonly ISubCategory _subCategory;
//private readonly IRating _rating;
//private readonly IReview _review;

//public AdminController(
//    IBook adminBook,
//    IUser adminUser,
//    IMainCategory category,
//    ISubCategory subCategory,
//    IRating rating,
//    IReview review

//    )
//{
//    _adminUser = adminUser;
//    _adminBook = adminBook;
//    _category = category;
//    _subCategory = subCategory;
//    _rating = rating;
//    _review = review;
//}

//public IActionResult Dashboard()
//{
//    var users = _adminUser.GetAllUsers();
//    ViewData["AllUsers"] = users;
//    var books = _adminBook.GetAllBooks();
//    ViewData["AllBooks"] = books;
//    var usersCount = users.Count;
//    var booksCount = books.Count;

//    ViewData["usersCount"] = usersCount;
//    ViewData["booksCount"] = booksCount;
//    return View();
//}