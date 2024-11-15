namespace MauiAppCadastroDeEventos.Models
{
    public class DuracaoEvento
    {

        public double QntPessoas { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public double ValorTotal { get; set; }
        public double ValorPessoa { get; set; }
        public string NomeEvento { get; set; }
        public string LocalEvento { get; set; }
        public int DuracaoTotal
        {
            get => DataFim.Subtract(DataInicio).Days;
        }


    }
}
