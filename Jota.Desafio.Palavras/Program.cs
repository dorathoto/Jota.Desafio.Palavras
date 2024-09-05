using Microsoft.ML;
using Microsoft.ML.Data;
using System.Data;
using static Jota.Desafio.Palavras.Program;

namespace Jota.Desafio.Palavras;
internal class Program
{
    public class DataSet
    {
        [VectorType(5)] // Fixar o vetor para 5 letras (ou outro valor que você escolha)
        public float[] Letras { get; set; }
        public float Pontuacao { get; set; } // Não fornecemos isso diretamente no teste
    }

    public class WordScorePrediction
    {
        [ColumnName("Score")]
        public float Score { get; set; }
    }

    static void Main(string[] args)
    {
        var mlContext = new MLContext();

        var data = new[]
        {//1º bug, esses modelos vão precisar de vetores com mesma qtd de caracteres logo coloquei um espaço em branco para completar :(
            new DataSet { Letras = new float[] { 1, 2, 1, 4, 0 }, Pontuacao = 8f },  // "abad"
            new DataSet { Letras = new float[] { 3, 1, 15, 0, 0 }, Pontuacao = 18f },  // "cao"
            new DataSet { Letras = new float[] { 21, 22, 1, 0, 0 }, Pontuacao = 44f },  // "uva"
            new DataSet { Letras = new float[] { 1, 0, 0, 0, 0 }, Pontuacao = 1f },  // "a"
            new DataSet { Letras = new float[] { 18, 15, 21, 16, 1 }, Pontuacao = 71f },  // "roupa"
            new DataSet { Letras = new float[] { 18, 15, 5, 21, 0 }, Pontuacao = 59f },  // "roeu"
            new DataSet { Letras = new float[] { 18, 1, 20, 15, 0 }, Pontuacao = 54f },  // "rato"
            new DataSet { Letras = new float[] { 18, 15, 13, 1, 0 }, Pontuacao = 47f },  // "roma"
            new DataSet { Letras = new float[] { 18, 5, 9, 0, 0 }, Pontuacao = 32f },  // "rei"
        };

        var trainData = mlContext.Data.LoadFromEnumerable(data);
        //################# executei cada modelo 3 vezes e mostro a pontuação, confirmando que o Sdca é o melhor, FastTree deverá ser melhor, mas não sei como implementar ainda

        // Sdca - regressão linear e não rede neural - teste 01 - pontuação (1000 interações: -28,752869; -19,983501; 13,248304) (100 interações: 11,020389; 
        var pipeline = mlContext.Transforms.Concatenate("Features", "Letras")
            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Pontuacao"
                        , maximumNumberOfIterations: 100));//maximumNumberOfIterations tipo epocas


        //Regressão de Poisson usando L-BFGS - teste 02 - pontuação 3,5847375; 3,5847375 ; 3,5847375
        //var pipeline = mlContext.Transforms.Concatenate("Features", "Letras")
        //    .Append(mlContext.Regression.Trainers.LbfgsPoissonRegression(
        //        labelColumnName: "Pontuacao"));


        //OnlineGradientDescent - teste 03 pontuação: 53906076 ; 539748300; 539748300
        //var pipeline = mlContext.Transforms.Concatenate("Features", "Letras")
        //    .Append(mlContext.Regression.Trainers.OnlineGradientDescent(
        //        labelColumnName: "Pontuacao", learningRate: 0.01f, numberOfIterations: 100));

        // Treinar o modelo
        var model = pipeline.Fit(trainData);

        var predictionEngine = mlContext.Model.CreatePredictionEngine<DataSet, WordScorePrediction>(model);

        // Testando o modelo com uma única palavra 'idade' que faz 23 pontos
        var newWord = new DataSet { Letras = new[] { 9f, 12f, 1f, 7f, 5f } }; // "idade"
        var prediction = predictionEngine.Predict(newWord);

        Console.WriteLine($"Pontuação prevista para 'idade': {prediction.Score}");

        var wordScores = data.ToDictionary(d => string.Concat(d.Letras.Where(l => l != 0).Select(l => (char)('a' + (int)l - 1))), d => d.Pontuacao);
        var sortedWordScores = wordScores.OrderByDescending(pair => pair.Value);

        int rank = 1;
        foreach (var pair in sortedWordScores)
        {
            Console.WriteLine($"{rank}. {pair.Key}: {pair.Value}");
            rank++;
        }
    }
}