namespace BancoApp;

public class PF : Cliente
{
    public PF(string codigo, string nome) : base(codigo, nome)
    {
        
    }

    public override decimal DescontarTaxa(decimal valor)
    {
        return valor - 1;
    }
}