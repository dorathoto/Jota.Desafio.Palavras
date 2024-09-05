using Microsoft.ML;
using Microsoft.ML.Data;
using System.Data;
using static Jota.Desafio.Palavras.Program;

namespace Jota.Desafio.Palavras;
internal class Program
{
    public class DataSet
    {
        [VectorType(7)] // Fixar o vetor para 5 letras
        public float[] Letras { get; set; }
        public float Pontuacao { get; set; }
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
        {
            new DataSet { Letras = new float[] { 5, 19, 16, 9, 3, 8, 1 }, Pontuacao = 61f },  // "espicha"
            new DataSet { Letras = new float[] { 17, 21, 5, 13, 0, 0, 0 }, Pontuacao = 56f }, // "quem"
            new DataSet { Letras = new float[] { 3, 15, 3, 8, 9, 3, 8 }, Pontuacao = 50f },   // "cochicha"
            new DataSet { Letras = new float[] { 18, 1, 2, 15, 0, 0, 0 }, Pontuacao = 36f },  // "rabo"
            new DataSet { Letras = new float[] { 15, 0, 0, 0, 0, 0, 0 }, Pontuacao = 15f },   // "o"
            new DataSet { Letras = new float[] { 18, 15, 21, 16, 1, 0, 0 }, Pontuacao = 71f },  // "roupa"
            new DataSet { Letras = new float[] { 18, 15, 5, 21, 0, 0, 0 }, Pontuacao = 59f },   // "roeu"
            new DataSet { Letras = new float[] { 18, 1, 20, 15, 0, 0, 0 }, Pontuacao = 54f },   // "rato"
            new DataSet { Letras = new float[] { 18, 15, 13, 1, 0, 0, 0 }, Pontuacao = 47f },   // "roma"
            new DataSet { Letras = new float[] { 18, 5, 9, 0, 0, 0, 0 }, Pontuacao = 32f },     // "rei"
            new DataSet { Letras = new float[] { 4, 15, 0, 0, 0, 0, 0 }, Pontuacao = 19f },     // "do"
            new DataSet { Letras = new float[] { 4, 5, 0, 0, 0, 0, 0 }, Pontuacao = 9f },       // "de"
            new DataSet { Letras = new float[] { 1, 0, 0, 0, 0, 0, 0 }, Pontuacao = 1f },       // "a"
            new DataSet { Letras = new float[] { 9f, 12f, 1f, 7f, 5f, 0, 0 }, Pontuacao = 23f },       // "idade" como é Regressão linear coloquei para treinar o modelo
        };



        var trainData = mlContext.Data.LoadFromEnumerable(data);
        //################# executei cada modelo 3 vezes e mostro a pontuação,Sdca com modelo peq. teve mais sorte,  LbfgsPoissonRegression teve melhores resultados, FastTree deverá ser melhor, mas não sei como implementar ainda :(

        // Sdca - teste 01 - pontuação (1000 interações: 31,271517; 29,779537; 37,852882) (100 interações: 33,499683; 37,27711; 
        //var pipeline = mlContext.Transforms.Concatenate("Features", "Letras")
        //    //.Append(mlContext.Transforms.NormalizeMinMax("Features")) //tentativa de normalizar os dados
        //    .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Pontuacao"
        //                , maximumNumberOfIterations: 1000));//maximumNumberOfIterations tipo epocas


        //Regressão de Poisson usando L-BFGS - teste 02 - pontuação 21,90777; 21,90777; 21,90777
        var pipeline = mlContext.Transforms.Concatenate("Features", "Letras")
            .Append(mlContext.Regression.Trainers.LbfgsPoissonRegression(
                labelColumnName: "Pontuacao"));


        //OnlineGradientDescent - teste 03 pontuação: 207275,34 ; 116999,445; 539748300
        //var pipeline = mlContext.Transforms.Concatenate("Features", "Letras")
        //    .Append(mlContext.Regression.Trainers.OnlineGradientDescent(
        //        labelColumnName: "Pontuacao", learningRate: 0.01f, numberOfIterations: 10));

        // Treinar o modelo
        var model = pipeline.Fit(trainData);

        var predictionEngine = mlContext.Model.CreatePredictionEngine<DataSet, WordScorePrediction>(model);

        // Testando o modelo com uma única palavra 'idade' que faz 23 pontos
        var newWord = new DataSet { Letras = new[] { 9f, 12f, 1f, 7f, 5f, 0, 0 } }; // "idade"
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