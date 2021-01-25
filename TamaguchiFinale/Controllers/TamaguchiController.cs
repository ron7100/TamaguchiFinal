using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TamaguchiFinale.Controllers
{
    [Route("Tamaguchi")]
    [ApiController]
    public class TamaguchiController : ControllerBase
    {

        [Route("SignIn")]
        [HttpPost]
        public bool sign_in([FromBody] string u, string pass)
        {

        }
    }

}
