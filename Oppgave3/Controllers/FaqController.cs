using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oppgave3.DAL;
using Oppgave3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Oppgave3.Controllers
{
    [ApiController]
    // dekoratøren over må være med; dersom ikke må post og put bruke [FromBody] som deoratør inne i prameterlisten
    [Route("api/[controller]")]
    public class FaqController : ControllerBase
    {
        private IFaqRepository _db;

        private ILogger<FaqController> _log;

        public FaqController(IFaqRepository db, ILogger<FaqController> log)
        {
            _db = db;
            _log = log;
        }

        [HttpPost]
        public async Task<ActionResult> Lagre(Faq innFaq)
        {
            if (ModelState.IsValid)
            {
                bool returOK = await _db.Lagre(innFaq);
                if (!returOK)
                {
                    _log.LogInformation("Kunden kunne ikke lagres!");
                    return BadRequest();
                }
                return Ok(); // kan ikke returnere noe tekst da klient prøver å konvertere deene som en Json-streng
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }

        [HttpGet]
        public async Task<ActionResult> HentAlle()
        {
            List<Faq> alleKunder = await _db.HentAlle();
            Console.WriteLine("" + alleKunder[0].Question + alleKunder[0].DownVotes);
            return Ok(alleKunder); 
        }

        

        /*[HttpGet("{id}")]
        public async Task<ActionResult> HentEn(int id)
        {
            if (ModelState.IsValid)
            {
                Faq faq = await _db.HentEn(id);
                if (faq == null)
                {
                    _log.LogInformation("Fant ikke kunden");
                    return NotFound();
                }
                return Ok(faq);
            }
            _log.LogInformation("Feil i inputvalidering");
            return BadRequest();
        }
        */

      
    }
}
