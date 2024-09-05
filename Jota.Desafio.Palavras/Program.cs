namespace Jota.Desafio.Palavras;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite uma frase, irei calcular a palavra de maior ranking:");
        string frase = Console.ReadLine();

        string[] palavras = frase.Split(' ');

        var resultado = palavras
            .Select(palavra => new { Palavra = palavra, Pontuacao = palavra.Sum(letra => letra - 'a' + 1) })
            .OrderByDescending(item => item.Pontuacao)
            .ThenBy(item => palavras.ToList().IndexOf(item.Palavra)) // Desempate pela ordem de entrada
            .First();

        Console.WriteLine("Palavra de maior pontuação: " + resultado.Palavra);
        Console.WriteLine("Pontuação: " + resultado.Pontuacao);
    }
}
