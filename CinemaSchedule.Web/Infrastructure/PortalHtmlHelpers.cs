using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CinemaSchedule.Core.Models;

namespace Cinema.Infrastructure
{
    public static class PortalHtmlHelpers
    {
        public static IEnumerable<SelectListItem> CreateSelectListFromLookup(
            this HtmlHelper html,
            IEnumerable<Lookup> lookup, 
            int selectedItemId = 0)
        {
            return lookup?.Select(l => new SelectListItem()
            {
                Value = l.Id.ToString(),
                Text = l.Name,
                Selected = l.Id == selectedItemId
            }) ?? new List<SelectListItem>();
        }
    }
}