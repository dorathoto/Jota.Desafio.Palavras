👨🏻‍💻 Bom, vamos lá, vou lançar meu desafio aqui, acredito que até (domingo 08-09-24) é uma boa data para entrega: 

✅ Desafio Jotinha 🤷🏻

Dada uma série de palavras, você precisa encontrar a palavra de maior pontuação.

Cada letra de uma palavra pontua de acordo com sua posição no alfabeto: a = 1, b = 2, c = 3 etc.

Por exemplo, a pontuação de abad É 8 (1 + 2 + 1 + 4).

Você precisa retornar a palavra de maior pontuação como uma string.

Se duas palavras marcam o mesmo, devolver a palavra que foi digitada primeiro.

Todas as letras serão minúsculas e todas as entradas serão válidas.

📅 Vamo que vamo, quero ver as tecnicas utilizadas, vou fazer a minha e depois discutimos as soluções.


---------

Fiz várias versões, cada uma em um branch diferente
--------



OBS: Bug em todas as versões, como utilizo a mesma resolução do desafio nilton (usar o Char para saber a pontuação da palavra) logo uma frase assim 'verde, amarelo' não existe a palavra verde e sim 'verde,'
verde: 54 pontos
verde,: 2 pontos
,: -52 pontos



**stage**
Versão básica, eficaz utilizando um loop, já que cada letra é sequencial seus pontos, logo basta fazer o loop para descobrir a pontuação.
Utilizando 2 variáveis secundárias para armazenar a maior pontuação e a palavra (poderia ser um dicionário)
Total de Linhas +- 30

**Ranking**
Mesma coisa da versão **stage** porém ele mostra todas as palavras e suas pontuações, criei para poder fazer a lista do MachineLearning**
Total de Linhas +- 30

**Linq**
Nesse branch fiz utilizando o Linq para calcular a palavra, com desempate

**MachineLearning**
Aqui não faço o algoritmo, faço apenas o ranking de algumas palavras e suas pontuações e tento fazer o computador descobrir como chegar a essa pontuação por palavra
ex:
falo que a palavra "abad" tem valor de 8, que a palavra "asdf" tem o valor de 30 e assim por diante, como ele chegará ao resultado é uma icognita, vai depender também da quantidade de palavras de treinamento.
Depois utilizo outra lista para verificar se ele chegou ao resultado, se tirar 100% é porque descobriu, caso contrário ele utilizou alguma outra solução que pode ter bom assertividade ou não.


Treinamento:
"O Rato roeu a roupa do rei de roma"
roupa: 71 pontos
roeu: 59 pontos
rato: 54 pontos
roma: 47 pontos
rei: 32 pontos
do: 19 pontos
o: 15 pontos
de: 9 pontos
a: 1 pontos

Essa frase mostrando que maiusculas e minusculas tem o mesmo valor, dando uma força pro ML
Quem cochicha o rabo espicha QuEM Cochicha O RABo espichA
espicha: 61 pontos
quem: 56 pontos
cochicha: 50 pontos
rabo: 36 pontos
o: 15 pontos

espicha: 61 pontos
QuEM: 56 pontos
Cochicha: 50 pontos
RABo: 36 pontos
O: 15 pontos
espichA: 9 pontos
