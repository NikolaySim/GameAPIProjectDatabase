using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Utilities
{
    public class LoadDataUtilities
    {

            public static SelectList LoadGamesData()
            {
                using (GameService.GameClient service = new GameService.GameClient())
                {
                    return new SelectList(service.GetGames(), "Id", "Title");
                }
            }
    }
}