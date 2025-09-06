namespace EFCore.Console.Domain
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; } = new();
    }
}
