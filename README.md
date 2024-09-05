👨🏻‍💻 Bom, vamos lá, vou lançar meu desafio aqui, acredito que até (domingo 08-09-24) é uma boa data para entrega: 

✅ Desafio Jotinha 🤷🏻

Dada uma série de palavras, você precisa encontrar a palavra de maior pontuação.

Cada letra de uma palavra pontua de acordo com sua posição no alfabeto: a = 1, b = 2, c = 3 etc.

Por exemplo, a pontuação de abad É 8 (1 + 2 + 1 + 4).

Você precisa retornar a palavra de maior pontuação como uma string.

Se duas palavras marcam o mesmo, devolver a palavra que foi digitada primeiro.

Todas as letras serão minúsculas e todas as entradas serão válidas.

📅 Vamo que vamo, quero ver as tecnicas utilizadas, vou fazer a minha e depois discutimos as soluções.


--------
Fiz várias versões, cada uma em um branch diferente

**master**
Versão básica, eficaz utilizando um loop, já que cada letra é sequencial seus pontos, logo basta fazer o loop para descobrir a pontuação.
Utilizando 2 variáveis secundárias para armazenar a maior pontuação e a palavra (poderia ser um dicionário)


**Linq**
Nesse branch fiz utilizando o Linq para calcular a palavra