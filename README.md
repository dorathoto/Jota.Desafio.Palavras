👨🏻‍💻 Bom, vamos lá, vou lançar meu desafio aqui, acredito que até (domingo 08-09-24) é uma boa data para entrega: 

✅ Desafio Jotinha 🤷🏻

Dada uma série de palavras, você precisa encontrar a palavra de maior pontuação.

Cada letra de uma palavra pontua de acordo com sua posição no alfabeto: a = 1, b = 2, c = 3 etc.

Por exemplo, a pontuação de abad É 8 (1 + 2 + 1 + 4).

Você precisa retornar a palavra de maior pontuação como uma string.

Se duas palavras marcam o mesmo, devolver a palavra que foi digitada primeiro.

Todas as letras serão minúsculas e todas as entradas serão válidas.

📅 Vamo que vamo, quero ver as tecnicas utilizadas, vou fazer a minha e depois discutimos as soluções.


--------a
Fiz várias versões, cada uma em um branch diferente

**stage**
Versão básica, eficaz utilizando um loop, já que cada letra é sequencial seus pontos, logo basta fazer o loop para descobrir a pontuação.
Utilizando 2 variáveis secundárias para armazenar a maior pontuação e a palavra (poderia ser um dicionário)
Total de Linhas +- 30

**Ranking**
Mesma coisa da versão **stage** porém ele mostra todas as palavras e suas pontuações:


**Linq**
Nesse branch fiz utilizando o Linq para calcular a palavra, com desempate

**MachineLearning**
Aqui não faço o algoritmo, faço apenas o ranking de algumas palavras e suas pontuações e tento fazer o computador descobrir como chegar a essa pontuação por palavra
ex:
falo que a palavra "abad" tem valor de 8, que a palavra "asdf" tem o valor de 30 e assim por diante, como ele chegará ao resultado é uma icognita, vai depender também da quantidade de palavras de treinamento.
Depois utilizo outra lista para verificar se ele chegou ao resultado, se tirar 100% é porque descobriu, caso contrário ele utilizou alguma outra solução que pode ter bom assertividade ou não.


Treinamento:
"O Rato roeu a roupa do rei de roma"
O
Rato
roeu
a=1
roupa=71
do
rei
de
roma
