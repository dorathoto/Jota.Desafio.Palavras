namespace Jota.Desafio.Palavras;
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Digite uma série de palavras separadas por espaço:");
        string frase = Console.ReadLine().ToLower();

        string[] palavras = frase.Split(' ');
        string palavraMaiorPontuacao = "";
        int maiorPontuacao = 0;

        foreach (string palavra in palavras)
        {
            int pontuacaoAtual = 0;
            foreach (char letra in palavra)
            {
                pontuacaoAtual += letra - 'a' + 1;
            }

            if (pontuacaoAtual > maiorPontuacao)
            {
                maiorPontuacao = pontuacaoAtual;
                palavraMaiorPontuacao = palavra;
            }
        }
        Console.WriteLine("Palavra de maior pontuação: " + palavraMaiorPontuacao);
        Console.WriteLine("Pontuação: " + maiorPontuacao);
    }
}