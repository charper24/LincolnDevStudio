using DevStudio.Models;
using DevStudio.WebAppBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevStudio.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = ApplicationDbContext.Create();
        private CommunityGroupDBContext db = new CommunityGroupDBContext();



        public ActionResult Index()
        {
            return View();
        }

        // POST: CommunityGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IndexViewModels model)
        {
            //Save Community Group form data to the communityGroupDb
            CommunityGroup group = new CommunityGroup();
            group.GroupName = model.GroupName;
            group.Url = model.Url;
            group.Description = model.GroupDescription;
            
            context.CommunityGroups.Add(group);
            context.SaveChanges();

            //Save person form data to the personDb
            Person person = new Person();
            person.CommunityGroup = group;
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            person.Email = model.Email;
            person.PhoneNumber = model.PhoneNumber;

            context.People.Add(person);
            context.SaveChanges();

            //Save request form data to the requestDb
            Request request = new Models.Request();
            request.Person = person;
            request.RequestDate = DateTime.Now;
            request.RequestDescription = model.RequestDescription;

           context.Requests.Add(request);
            context.SaveChanges();

            return RedirectToAction("Index");
        }



        public ActionResult ViewSubmissions()
        {
            HomeService HomeService = new HomeService();

            return View(HomeService.getAllSubmissions());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}