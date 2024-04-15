namespace ContaCorrente.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Cliente cliente1 = new Cliente();
            cliente1.nome = "Vanessa";
            cliente1.sobrenome = "Nunes";
            cliente1.cpf = "123.456.789-10";

            ContaCorrente conta1 = new ContaCorrente();
            conta1.titular = cliente1;
            conta1.saldo = 5000.00M;
            conta1.status = "especial".ToUpper();
            Console.WriteLine(conta1.verificaStatus());

            Cliente cliente2 = new Cliente();
            cliente2.nome = "Luis Eduardo";
            cliente2.sobrenome = "Maia";
            cliente2.cpf = "987.654.321-00";

            ContaCorrente conta2 = new ContaCorrente();
            conta2.titular = cliente2;
            conta2.saldo = 1000.00M;
            conta1.status = "normal".ToUpper();
            Console.WriteLine(conta2.verificaStatus());

            Console.WriteLine(conta1.VisualizarSaldo());
            //Console.WriteLine(conta2.VisualizarSaldo());

            Console.WriteLine(conta1.Transferir(conta2, 6000));

            Console.WriteLine(conta1.Depositar());
            Console.WriteLine(conta1.Sacar());
            

            Console.WriteLine(conta1.VisualizarExtrato());

            Console.ReadLine();
        }
    }
}