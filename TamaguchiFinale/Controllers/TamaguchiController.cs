using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TamaguchiClasses.Models;
using TamaguchiFinale.DataTransferObjects;

namespace TamaguchiFinale.Controllers
{
    [Route("Tamaguchi")]
    [ApiController]
    public class TamaguchiController : ControllerBase
    {
        TryTamaContext context;
        public TamaguchiController(TryTamaContext context)
        {
            this.context = context;
        }
        [Route("SignIn")]
        [HttpGet]
        public PlayerDTO sign_in([FromQuery] string username, [FromQuery] string password)
        {
            Player p = Player.find_player(username, password);

            //Check user name and password
            if (p != null)
            {
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        [Route("SignUp")]
        [HttpPost]
        public PlayerDTO sign_up([FromQuery] Player p)
        {
            //Check user name and password
            if (p != null)
            {
                p.sign_up();
                PlayerDTO pDTO = new PlayerDTO(p);

                HttpContext.Session.SetObject("player", pDTO);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return pDTO;
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }
    }
}
