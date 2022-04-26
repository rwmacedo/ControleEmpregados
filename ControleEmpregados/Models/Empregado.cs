namespace ControleEmpregados.Models
{
    public class Empregado
    {
        public long? EmpregadoID { get; set; }
        public int MATRICULA { get; set; }
        public string NOME { get; set; }
        public string DATA_DE_NASCIMENTO { get; set; }
        public string FUNCAO { get; set; }
        public string ESCOLARIDADE { get; set; }
    }
}
