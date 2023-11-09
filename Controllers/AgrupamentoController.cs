using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;
using Trabalho.Models.Agrupamento;

namespace Trabalho.Controllers
{
    public class AgrupamentoController : Controller
    {

        private readonly Contexto contexto;

        public AgrupamentoController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ConsultaAgr> lstConsulta =
                from item in contexto.Consulta
                .Include(pa=>pa.paciente).Include(med=>med.medico).Include(medi=>medi.Medicamento_Injetaveis)
                .OrderBy(o => o.medico.nome)
                .ToList()
                select new ConsultaAgr
                {
                    Id = item.id,
                    nomeMed = item.medico.nome,
                    especialidade = item.medico.especialidade,
                    nomePa = item.paciente.nome,
                    nomeMedicamento = item.Medicamento_Injetaveis.nome,
                    QtdeUsada = item.Qtde_Vacina
                };

            return View(lstConsulta);
        }
    }
}
