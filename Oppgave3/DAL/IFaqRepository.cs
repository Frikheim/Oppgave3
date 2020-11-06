using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Oppgave3.Model;

namespace Oppgave3.DAL
{
    public interface IFaqRepository
    {
        Task<bool> Lagre(Faq faq);
        Task<List<Faq>> HentAlle();
        
    }
}
