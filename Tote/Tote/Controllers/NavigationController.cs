using Business.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.Models;

namespace Tote.Controllers
{
    public class NavigationController : Controller
    {
        private IRateListProvider rateListProvider;

        public NavigationController(IRateListProvider rateListProvider)
        {
            this.rateListProvider = rateListProvider;
        }

        // GET: Navigation
        public ActionResult Index()
        {
            IList<RateList> rates = rateListProvider.GetRateList(1, 1);
            return View(rates[0]);
        }

        public PartialViewResult ChildTournament(int id = 0)
        {
            IList<Tournament> tournaments = rateListProvider.GetTournament(id);            
            return PartialView(tournaments);
        }

        public PartialViewResult Menu(int category = 0)
        {
            ViewBag.SelectedCategory = category;
            IList<Sport> sports = rateListProvider.GetSports();
            return PartialView(sports);
        }

        public ActionResult Rate(int id)
        {
            IList<RateList> rates = rateListProvider.GetRateAll();
            RateList rate = new RateList();
            foreach(RateList r in rates)
            {
                if(r.RateId==id)
                {
                    rate = r;
                }
            }
            return View(rate);
        }

        public ViewResult List(int? SportId, int? TournamentId = null)
        {              
            IList<RateList> rates = rateListProvider.GetRateList(SportId, TournamentId);
            return View(rates);
        }


    }
}