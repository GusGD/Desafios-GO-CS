using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;

class Program
{
    static void Main()
    {
        Desafio1();
        Desafio2();
        Desafio3();
        Desafio4();
        Desafio5();
    }

    static void Desafio1()
    {
        int INDICE = 13;
        int SOMA = 0;
        int K = 0;

        while (K < INDICE)
        {
            K++;
            SOMA += K;
        }

        Console.WriteLine("Desafio 1 - Soma: " + SOMA);
        Console.WriteLine();
    }

    static void Desafio2()
    {
        Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
        int numero = int.Parse(Console.ReadLine());

        int a = 0, b = 1;
        while (b < numero)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }

        if (b == numero || numero == 0)
        {
            Console.WriteLine($"Desafio 2: O número {numero} pertence à sequência de Fibonacci.");
        }
        else
        {
            Console.WriteLine($"Desafio 2: O número {numero} NÃO pertence à sequência de Fibonacci.");
        }
        Console.WriteLine();
    }

    class DiaFaturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }

static void Desafio3()
{
    try
    {
        // JSON de teste embutido (simulando diaFaturamento.json)
        string json = @"
        [
            { ""Dia"": 1, ""Valor"": 22174.1664 },
            { ""Dia"": 2, ""Valor"": 24537.6698 },
            { ""Dia"": 3, ""Valor"": 26139.6134 },
            { ""Dia"": 4, ""Valor"": 0.0 },
            { ""Dia"": 5, ""Valor"": 0.0 },
            { ""Dia"": 6, ""Valor"": 26742.6612 },
            { ""Dia"": 7, ""Valor"": 0.0 },
            { ""Dia"": 8, ""Valor"": 42889.2258 },
            { ""Dia"": 9, ""Valor"": 46251.174 },
            { ""Dia"": 10, ""Valor"": 11191.4722 },
            { ""Dia"": 11, ""Valor"": 0.0 },
            { ""Dia"": 12, ""Valor"": 0.0 },
            { ""Dia"": 13, ""Valor"": 3847.4823 },
            { ""Dia"": 14, ""Valor"": 373.7838 },
            { ""Dia"": 15, ""Valor"": 2659.7563 },
            { ""Dia"": 16, ""Valor"": 48924.2448 },
            { ""Dia"": 17, ""Valor"": 18419.2614 },
            { ""Dia"": 18, ""Valor"": 0.0 },
            { ""Dia"": 19, ""Valor"": 0.0 },
            { ""Dia"": 20, ""Valor"": 35240.1826 },
            { ""Dia"": 21, ""Valor"": 43829.1667 },
            { ""Dia"": 22, ""Valor"": 18235.6852 },
            { ""Dia"": 23, ""Valor"": 4355.0662 },
            { ""Dia"": 24, ""Valor"": 13327.1025 },
            { ""Dia"": 25, ""Valor"": 0.0 },
            { ""Dia"": 26, ""Valor"": 0.0 },
            { ""Dia"": 27, ""Valor"": 25681.8318 },
            { ""Dia"": 28, ""Valor"": 1718.1221 },
            { ""Dia"": 29, ""Valor"": 13220.495 },
            { ""Dia"": 30, ""Valor"": 8414.61 }
        ]";

        var dados = JsonSerializer.Deserialize<List<DiaFaturamento>>(json);

        if (dados == null || dados.Count == 0)
        {
            Console.WriteLine("Desafio 3: Nenhum dado encontrado.");
            return;
        }

        double soma = 0, menor = double.MaxValue, maior = double.MinValue;
        int diasComFaturamento = 0;

        foreach (var d in dados)
        {
            if (d.Valor > 0)
            {
                soma += d.Valor;
                diasComFaturamento++;

                if (d.Valor < menor)
                    menor = d.Valor;

                if (d.Valor > maior)
                    maior = d.Valor;
            }
        }

        if (diasComFaturamento == 0)
        {
            Console.WriteLine("Desafio 3: Nenhum dia com faturamento positivo.");
            return;
        }

        double media = soma / diasComFaturamento;
        int diasAcimaDaMedia = dados.Count(d => d.Valor > media);

        Console.WriteLine("Desafio 3:");
        Console.WriteLine($"Menor valor de faturamento: R${menor:F2}");
        Console.WriteLine($"Maior valor de faturamento: R${maior:F2}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao processar os dados: " + ex.Message);
    }
}

    static void Desafio4()
    {
        var valores = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double total = valores.Values.Sum();

        Console.WriteLine("Desafio 4 - Percentual de faturamento por estado:");
        foreach (var estado in valores)
        {
            double percentual = (estado.Value / total) * 100;
            Console.WriteLine($"{estado.Key}: {percentual:F2}%");
        }
        Console.WriteLine();
    }

    static void Desafio5()
    {
        Console.Write("Digite uma palavra para inverter: ");
        string palavra = Console.ReadLine().Trim();

        char[] arr = palavra.ToCharArray();
        Array.Reverse(arr);
        string invertida = new string(arr);

        Console.WriteLine($"Desafio 5: A palavra invertida é: {invertida}");
    }
}
