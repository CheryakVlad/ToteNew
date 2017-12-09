﻿using Business.Providers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace Tote.Controllers
{
    public class SortController : Controller
    {
        private IBetListProvider betListProvider;
        private readonly IMatchProvider matchProvider;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(SortController));

        public SortController(IBetListProvider rateListProvider, IMatchProvider matchProvider)
        {
            this.betListProvider = rateListProvider;
            this.matchProvider = matchProvider;
        }
        [HttpGet]
        public ActionResult Sort()
        {            
            SelectList sports = new SelectList(betListProvider.GetSports(), "SportId", "Name");
            ViewBag.Sports = sports;
            string[] statuses=new string[]{ "Past Events","Current Events","Furure Events"};
            SelectList status = new SelectList(statuses);
            ViewBag.Statuses = status;

            IReadOnlyList<Match> matches = matchProvider.GetMatchBySportDateStatus(0,"",0);
            if (matches.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(matches);
            /*IReadOnlyList<Match> bets = betListProvider.GetMatchesAll();
            if (bets.Count == 0)
            {
                return RedirectToAction("InfoError", "Navigation");
            }
            return View(bets);*/
        }
        [HttpGet]
        public ActionResult Match(int sportId, string dateMatch, int status)
        {                       
            /*IReadOnlyList<Match> bets = new List<Match>();
            try
            {
                bets = betListProvider.GetBetList(sportId, 0);
                if (bets == null)
                {
                    return RedirectToAction("InfoError", "Navigation");
                }
            }*/

            IReadOnlyList<Match> matches = new List<Match>();
            try
            {
                matches = matchProvider.GetMatchBySportDateStatus(sportId, dateMatch, status);
                if (matches == null)
                {
                    return RedirectToAction("InfoError", "Navigation");
                }
            }

            catch (FaultException faultEx)
            {
                LogAndRedirect(faultEx);
            }
            catch (SqlException sqlEx)
            {
                LogAndRedirect(sqlEx);
            }

            return PartialView(matches);
        }
        public ActionResult LogAndRedirect(Exception ex)
        {
            log.Error(ex.Message + " " + ex.StackTrace);
            return RedirectToAction("InfoError", "Navigation");
        }
    }
}