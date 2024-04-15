namespace ContaCorrente.ConsoleApp
{
    public class Movimentacoes
    {
        public decimal valor;
        public string tipo;

        public string Extrato()
        {
            return $"\nTipo: {tipo}, Valor: {valor}";
        }

    }
}
