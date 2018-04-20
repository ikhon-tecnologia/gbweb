using Ikhon.GBWeb.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ikhon.GBWeb.Application.Interfaces
{
    public interface IGBWEbAppService : IDisposable
    {
        ICollection<EventoViewModel> ListarEvento();
        EventoViewModel IncluirEvento(EventoViewModel evento);
        EventoViewModel AlterarEvento(EventoViewModel evento);
        EventoViewModel CarregarEvento(int cod_evento);
        void ExcluirEvento(int cod_evento);
    }
}
