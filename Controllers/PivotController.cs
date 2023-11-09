using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;
using Trabalho.Models.Agrupamento;
using Trabalho.Models.Pivot;

namespace Trabalho.Controllers
{
    public class PivotController : Controller
    {

        private readonly Contexto contexto;

        public PivotController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Index()
        {
            IEnumerable<ConsultaAgr> lstConsulta =
                from item in contexto.Consulta
                .Include(pa => pa.paciente).Include(med => med.medico).Include(medi => medi.Medicamento_Injetaveis)
                .OrderBy(o => o.medico.nome)
                .ToList()
                select new ConsultaAgr
                {
                    Id = item.medico.crm,
                    nomeMed = item.medico.nome,
                    especialidade = item.medico.especialidade,
                    nomePa = item.paciente.nome,
                    nomeMedicamento = item.Medicamento_Injetaveis.nome,
                    QtdeUsada = item.Qtde_Vacina
                };

            IEnumerable<ConsultaPivot> lstPivot =
                from item in lstConsulta
                .ToList()
                group item by new { item.Id, item.nomeMed, item.nomeMedicamento}
                into grupo
                orderby grupo.Key.nomeMed
                select new ConsultaPivot
                {
                    Id = grupo.Key.Id,
                    nomeMed = grupo.Key.nomeMed,
                    nomeMedicamento = grupo.Key.nomeMedicamento,
                    QtdeUsada = grupo.Sum(o => o.QtdeUsada)
                };

            return View(lstPivot);
        }
    }
}
