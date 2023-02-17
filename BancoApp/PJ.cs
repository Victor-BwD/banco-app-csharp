namespace BancoApp;

public class PJ : Cliente
{
    public PJ(string codigo, string nome) : base(codigo, nome)
    {
    }

    public override decimal DescontarTaxa(decimal valor)
    {
        return valor - 2;  
    }
}