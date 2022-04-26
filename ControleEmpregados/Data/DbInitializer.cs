
using ControleEmpregados.Models;
using System.Linq;


namespace ControleEmpregados.Data
{
    public class DbInitializer
    {
       public static void Initialize(AppDBContext context)
        {
            //context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            if (context.Empregados.Any())
            {
                return;
            }

            var empregados = new Empregado[]
            {
                new Empregado { MATRICULA=000123, NOME="Fulano", DATA_DE_NASCIMENTO= "11/11/1980", FUNCAO="Gerente", ESCOLARIDADE ="Superior" },
                new Empregado { MATRICULA=000456, NOME="Ciclano", DATA_DE_NASCIMENTO= "01/01/1990", FUNCAO="Assistente", ESCOLARIDADE ="Médio" }
            };
                
            foreach (Empregado d in empregados)
            {
                context.Empregados.Add(d);
            }
            context.SaveChanges();
        }
    }
}