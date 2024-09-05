namespace Jota.Desafio.Palavras;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite uma série de palavras separadas por espaço:");
        string input = Console.ReadLine();

        string[] palavras = input.Split(' ');

        var resultado = palavras
            .Select(palavra => new { Palavra = palavra, Pontuacao = palavra.Sum(letra => letra - 'a' + 1) })
            .OrderByDescending(item => item.Pontuacao)
            .ThenBy(item => palavras.ToList().IndexOf(item.Palavra)) // Desempate pela ordem de entrada
            .First();

        Console.WriteLine("Palavra de maior pontuação: " + resultado.Palavra);
        Console.WriteLine("Pontuação: " + resultado.Pontuacao);
    }
}
