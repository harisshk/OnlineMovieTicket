﻿using System.Web.Mvc;

namespace OnlineMovieTicket
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

           
        }
    }
}
