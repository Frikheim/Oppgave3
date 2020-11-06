using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oppgave3.DAL
{
    public static class DBInit
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            
            var db = serviceScope.ServiceProvider.GetService<FaqContext>();

            // må slette og opprette databasen hver gang når den skal initieres (seed`es)
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var faq1 = new Faqs
            {
                Question = "Hva betyr % tallene ved noen av billettypene? ",
                Answer = "Det er rabatten disse bilettypene får i forhold til standardprisen på voksenbillett",
                Category = "Billett",
                UpVotes = 2,
                DownVotes = 5
            };

            var spørsmål2 = new Faqs
            {
                Question = "Jeg får ikke laget bruker for å logge inn",
                Answer = "Innlogging er desverre kun for administratoer, innlogging for kunder kommer snart",
                Category = "Innlogging",
                UpVotes = 0,
                DownVotes = 30
            };

            var spørsmål3 = new Faqs
            {
                Question = "Hvorfor vises ikke returvarianten av rutene?",
                Answer = "Rutene er begge retninger slik at en egen returrute ikke trenges",
                Category = "Rute",
                UpVotes = 10,
                DownVotes = 1
            };

            var spørsmål4 = new Faqs
            {
                Question = "Hvorfor kommer man ikke tilbake til bilettbestillingen fra faqsiden",
                Answer = "faqsiden ble laget i et annet prosjekt enn billettbestillingen",
                Category = "Annet",
                UpVotes = 0,
                DownVotes = 0
            };

            db.Faqs.Add(faq1);
            db.Faqs.Add(spørsmål2);
            db.Faqs.Add(spørsmål3);
            db.Faqs.Add(spørsmål4);

            db.SaveChanges();
        }
    }  
}
