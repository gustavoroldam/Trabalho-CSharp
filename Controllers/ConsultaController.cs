using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly Contexto contexto;

        public ConsultaController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult consulta(string busca)
        {
            var consulta = contexto.Consulta.Include(pa=>pa.paciente)
                                            .Include(med=>med.medico)
                                            .Include(medi=>medi.Medicamento_Injetaveis)
                                            .Where(pa => pa.paciente.nome.Contains(busca))
                                            .ToList();

            return View(consulta);
        }
    }
}
