using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oppgave3.Model;
using Microsoft.EntityFrameworkCore;

namespace Oppgave3.DAL
{
    public class FaqRepository : IFaqRepository
    {
        private readonly FaqContext _db;

        public FaqRepository(FaqContext db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Faq faq)
        {
            try
            {
                var nyFaqRad = new Faqs();
                nyFaqRad.Question = faq.Question;
                nyFaqRad.Answer = faq.Answer;
                nyFaqRad.Category = faq.Category;
                nyFaqRad.UpVotes = faq.UpVotes;
                nyFaqRad.DownVotes = faq.DownVotes;

                _db.Faqs.Add(nyFaqRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Faq>> HentAlle()
        {
            try
            {
                List<Faq> allFaqs = await _db.Faqs.Select(k => new Faq
                {
                    Id = k.Id,
                    Question = k.Question,
                    Answer = k.Answer,
                    Category = k.Category,
                    UpVotes = k.UpVotes,
                    DownVotes = k.DownVotes
                }).ToListAsync();
                return allFaqs;
            }
            catch
            {
                return null;
            }
        }
    }
}