using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trabalho.Models;

namespace Trabalho.Controllers
{
    public class GeradorController : Controller
    {

        private readonly Contexto contexto;

        public GeradorController(Contexto context)
        {
            contexto = context;
        }

        public IActionResult Index()
        {
            /*Consultas*/
            contexto.Database.ExecuteSqlRaw("delete from Consulta");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Consulta', RESEED, 0)");

            /*Paciente*/
            contexto.Database.ExecuteSqlRaw("delete from Paciente");
            //contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Paciente', RESEED, 0)");

            for (int i = 1; i <= 10; i++)
            {
                Paciente pa = new Paciente();

                pa.cpf = i;
                pa.nome = "Paciente " + i;
                pa.telefone = i;
                pa.endereco = "Endereço " + i;

                contexto.Paciente.Add(pa);
            }

            /*Medico*/
            contexto.Database.ExecuteSqlRaw("delete from Medico");
            //contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Medico', RESEED, 0)");

            Random randNum = new Random();
            string[] vEspecialidade = { "Cardiologista", "Ortopedista", "Pediatra"};

            for (int i = 1; i <= 10; i++)
            {
                Medico med = new Medico();

                med.crm = i;
                med.nome = "Medico " + i;
                med.telefone = i;
                med.especialidade = vEspecialidade[randNum.Next() % 3].ToLower();

                contexto.Medicos.Add(med);
            }

            /*Medicamento*/
            contexto.Database.ExecuteSqlRaw("delete from Medicamentos");
            contexto.Database.ExecuteSqlRaw("DBCC CHECKIDENT('Medicamentos', RESEED, 0)");

            for (int i = 1; i <= 10; i++)
            {
                Medicamento_Injetaveis medi = new Medicamento_Injetaveis();

                medi.nome = "Medicamento " + i;
                medi.Qtde_Estoque = i * 10;
                medi.unidade = "ml";

                contexto.Medicamento_Injetaveis.Add(medi);
            }

            contexto.SaveChanges();


            return View();
        }
    }
}
