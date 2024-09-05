namespace Jota.Desafio.Palavras;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite uma frase, irei calcular a palavra de maior ranking");
        string frase = Console.ReadLine().ToLower();

        string[] palavras = frase.Split(' ');

        Dictionary<string, int> ranking = new Dictionary<string, int>();

        foreach (string palavra in palavras)
        {
            int pontuacaoAtual = 0;
            foreach (char letra in palavra)
            {
                pontuacaoAtual += letra - 'a' + 1;
            }

            ranking[palavra] = pontuacaoAtual;
        }

        var palavrasOrdenadas = ranking.OrderByDescending(pair => pair.Value);
        foreach (var item in palavrasOrdenadas)
        {
            Console.WriteLine($"{item.Key}: {item.Value} pontos");
        }
    }
}