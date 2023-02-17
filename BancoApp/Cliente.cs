namespace BancoApp;

public class Cliente
{
    public string Codigo { get; private set; }
    public string Nome { get; private set; }
    public decimal Saldo { get; private set; }

    public Cliente()
    {
        
    }

    public Cliente(string codigo, string nome) : this()
    {
        Codigo = codigo;
        Nome = nome;
    }

    public void RealizarSaque(decimal valor)
    {
        if (Saldo >= valor)
        {
            var valorMenosTaxa = DescontarTaxa(valor);
            Saldo -= valorMenosTaxa;
            Console.WriteLine($"Saque realizado com sucesso. Saldo: {Saldo}");
        }
        else
        {
            Console.WriteLine("Saldo insuficiente!");
        }
    }

    public void RealizarDeposito(decimal valor)
    {
        var valorMenosTaxa = DescontarTaxa(valor);
        Saldo += valorMenosTaxa;
        Console.WriteLine($"Valor depositado com sucesso. Saldo: {Saldo}");
    }

    public virtual decimal DescontarTaxa(decimal valor)
    {
        return valor;
    }
}