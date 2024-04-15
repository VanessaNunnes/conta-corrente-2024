namespace ContaCorrente.ConsoleApp
{
    public class ContaCorrente
    {
        public Cliente titular;
        public int numeroConta;
        public decimal saldo, limite, valorSacado, valorDepositado;
        public string status;
        public Movimentacoes[] historico = new Movimentacoes[100];
        public int operacoesRealizadas = 0;

        public string verificaStatus()
        {
            if (status == "ESPECIAL")
            {
                limite = 10000M;
            }
            else if (status == "NORMAL")
            {
                limite = 1000M;
            }
            else
            {
                return "tipo de conta invalida";
            }
            return $"sua conta é {status} e seu limite é de R${limite}";
        }
        public string VisualizarSaldo()
        {
            return $"{titular.nome}, o seu saldo é de R${saldo}";
        }
        public string VisualizarExtrato()
        {
            string extrato = "";
            for (int i = 0; i < 100; i++)
            {
                if (historico[i] != null)
                {
                    extrato += $"{historico[i].Extrato()}";
                }
            }
            return extrato;
        }

        public string Sacar()
        {
            Console.WriteLine("Informe o valor do saque: ");
            valorSacado += Convert.ToDecimal(Console.ReadLine());

            if (valorSacado <= limite && valorSacado <= saldo)
            {
                saldo -= valorSacado;
                limite -= valorSacado;
                return $"Saque realizado com sucesso. Você ainda pode sacar R${limite}";
            }
            else if (valorSacado > limite)
            {
                return $"Você excedeu o seu limite diário de saques. Limite de saques: R${limite}";
            }
            else if (valorSacado > saldo)
            {
                return "Saldo Insuficiente";
            }
            Movimentacoes movimentacao = new Movimentacoes();
            movimentacao.valor = valorSacado;
            movimentacao.tipo = "Saque";
            historico[operacoesRealizadas] = movimentacao;
            operacoesRealizadas++;
            return $"Seu saldo é de: R${saldo}";
        }

        public string Depositar()
        {
            Console.Write("Informe o valor do depósito: ");
            valorDepositado += Convert.ToDecimal(Console.ReadLine());

            if (valorDepositado <= 0)
            {
                return "Valor inválido para depósito.";
            }
            else if (valorDepositado > saldo)
            {
                return "Saldo Insuficiente";
            }

            saldo -= valorDepositado;
            Movimentacoes movimentacao = new Movimentacoes();
            movimentacao.valor = valorDepositado;
            movimentacao.tipo = "Depósito";
            historico[operacoesRealizadas] = movimentacao;
            operacoesRealizadas++;
            return "";
        }

        public string Transferir(ContaCorrente destino, decimal valor)
        {
            if (valor <= 0)
            {
                return "Valor inválido para transferência.";

            }
            else if (valor > saldo)
            {
                return "Saldo Insuficiente";
            }

            saldo -= valor;
            destino.saldo += valor;
            Movimentacoes movimentacao = new Movimentacoes();
            movimentacao.valor = valorSacado;
            movimentacao.tipo = "Transferência";
            historico[operacoesRealizadas] = movimentacao;
            operacoesRealizadas++;
            return "";
        }
    }
}