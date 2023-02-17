using BancoApp;

List<Cliente> clientes = new List<Cliente>();
ConsultarCliente();

void ConsultarCliente()
{
    Console.WriteLine("Olá, bem vindo ao banco.");
    Console.WriteLine("Digite seu código: ");
    var codigo = Console.ReadLine();
    Cliente cliente = null;
    
    foreach (var cli in clientes)
    {
        if (cli.Codigo == codigo)
        {
            cliente = cli;
        }
    }

    if (ReferenceEquals(cliente, null))
    {
        Console.WriteLine("Este cliente não existe, deseja cadastrar? Digite S ou N");
        var cadastrarClientePergunta = Console.ReadLine().ToLower();
        if (cadastrarClientePergunta == "s")
        {
            Console.WriteLine("Digite o código: ");
            var codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite seu nome: ");
            var nomeClienteNovo = Console.ReadLine();
            Console.WriteLine("PF ou PJ: ");
            var tipoPessoa = Console.ReadLine().ToUpper();
            if (tipoPessoa == "PF")
            {
                if (codigoClienteNovo != null)
                    if (nomeClienteNovo != null)
                        cliente = new PF(codigoClienteNovo, nomeClienteNovo);
            }
            else
            {
                if (codigoClienteNovo != null)
                    if (nomeClienteNovo != null)
                        cliente = new PJ(codigoClienteNovo, nomeClienteNovo);
            }
            clientes.Add(cliente);
            ExibirMenu(cliente);
        }
        else
        {
            ConsultarCliente();
        }
    }
}

void ExibirMenu(Cliente cliente)
{
    Console.WriteLine($"Olá, {cliente.Nome}");
    Console.WriteLine("Digite a opção desejada: ");
    Console.WriteLine("1 - Sacar");
    Console.WriteLine("2 - Depositar");

    var menuEscolha = Console.ReadLine();

    switch (menuEscolha)
    {
        case "1":
            RealizarSaque(cliente);
            break;
        case "2":
            RealizarDeposito(cliente);
            break;
        default:
            Console.WriteLine("Digite a opção correta.");
            ExibirMenu(cliente);
            break;
    }
    
}

void RealizarSaque(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja sacar: ");
    var valor = Console.ReadLine();
    cliente.RealizarSaque(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transação? S ou N");
    var realizarOutraTransacao = Console.ReadLine().ToLower();
    if (realizarOutraTransacao == "s")
    {
        ExibirMenu(cliente);
    }
    else
    {
        Console.WriteLine("Até mais!");
    }
}

void RealizarDeposito(Cliente cliente)
{
    Console.WriteLine("Digite o valor do depósito: ");
    var valor = Console.ReadLine();
    cliente.RealizarDeposito(Convert.ToDecimal(valor));
    Console.WriteLine("Deseja realizar outra transação? S ou N");
    var realizarOutraTransacao = Console.ReadLine().ToLower();
    if (realizarOutraTransacao == "s")
    {
        ExibirMenu(cliente);
    }
    else
    {
        Console.WriteLine("Até mais!");
    }
}
