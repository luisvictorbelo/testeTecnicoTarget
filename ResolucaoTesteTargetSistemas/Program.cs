using ResolucaoTesteTargetSistemas.Functions;
using System.Text.Json;
using ResolucaoTesteTargetSistemas.Classes;

// Exibe menu
while (true)
{
    Console.WriteLine("Selecione a questão que você deseja responder:");
    Console.WriteLine("1 - Questão 1: Valor da variável SOMA");
    Console.WriteLine("2 - Questão 2: Sequência de Fibonacci");
    Console.WriteLine("3 - Questão 3: Faturamento da Distribuidora");
    Console.WriteLine("4 - Questão 4: Porcentagem de Faturamento");
    Console.WriteLine("5 - Questão 5: Inverter String");
    Console.WriteLine("0 - Sair");

    int opcao = LerOpcao();

    switch (opcao)
    {
        case 1:
            Questao1();
            break;
        case 2:
            Questao2();
            break;

        case 3:
            Questao3();
            break;

        case 4:
            Questao4();
            break;

        case 5:
            Questao5();
            break;

        case 0:
            Console.WriteLine("Encerrando.");
            return;
        default:
            Console.WriteLine("\nOpção Inválida.");
            break;
    }
    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
    Console.ReadKey();
    Console.Clear();
}


static int LerOpcao()
{
    while (true)
    {
        Console.Write("Escolha uma opção: ");
        if (int.TryParse(Console.ReadLine(), out int opcao) && opcao >= 0 && opcao <= 5)
        {
            return opcao;
        }
        else
        {
            Console.WriteLine("Opção inválida, tente novamente.");
        }
    }
}

static void Questao1()
{
    int INDICE = 13;
    int SOMA = 0;
    int K = 0;

    while (K < INDICE)
    {
        K += 1;
        SOMA += K;
    }
    // SOMA = 91
    Console.WriteLine($"Valor da variável soma: {SOMA}");
}

static void Questao2()
{
    // Altere pelo número desejado
    int entrada = 8;

    bool resultado = Fibonacci.CalcularFibonacci(entrada);

    if(resultado == true)
    {
        Console.WriteLine($"O número {entrada} faz parte da sequência");
    }
    else {
        Console.WriteLine($"O número {entrada} não faz parte da sequência");
    }
}

static void Questao3()
{
    string caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "dados.json");
    string json = File.ReadAllText(caminhoArquivo);
    List<Faturamento> faturamentos = JsonSerializer.Deserialize<List<Faturamento>>(json, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
    });

    decimal menorValor = Faturamento.MenorFaturamento(faturamentos);

    decimal maiorValor = Faturamento.MaiorFaturamento(faturamentos);

    decimal media = Faturamento.Media(faturamentos);

    int diasAcimaDaMedia = Faturamento.DiasAcimaDaMedia(faturamentos, media);

    Console.WriteLine($"Menor faturamento: {menorValor}");
    Console.WriteLine($"Maior faturamento: {maiorValor}");
    Console.WriteLine($"Dias acima da média: {diasAcimaDaMedia}");
}

static void Questao4()
{
    var estados = new[] {
    new { Estado = "SP", Faturamento = 67836.43 },
    new { Estado = "RJ", Faturamento = 36678.66 },
    new { Estado = "MG", Faturamento = 29229.88 },
    new { Estado = "ES", Faturamento = 27165.48 },
    new { Estado = "Outros", Faturamento = 19849.53 }
};

    double faturamentoTotal = estados.Sum(e => e.Faturamento);
    var porcentagens = estados.Select(e => new
    {
        e.Estado,
        Porcentagem = e.Faturamento / faturamentoTotal * 100
    }).ToArray();

    Console.WriteLine("Porcentagem de faturamento por estado:");
    foreach (var item in porcentagens)
    {
        Console.WriteLine($"Estado: {item.Estado}, Porcentagem de Faturamento: {item.Porcentagem:F2}%");
    }
}

static void Questao5()
{
    // Altere a entrada aqui
    string entrada = "string";
    
    string stringInvertida = "";

    for (int i = entrada.Length - 1; i >= 0; i--)
    {
        stringInvertida += entrada[i];
    }

    Console.WriteLine($"String original: {entrada}");
    Console.WriteLine($"String invertida: {stringInvertida}");
}

