import numpy as np
import tensorflow as tf
from tensorflow.keras import layers, models
#mesmo dataset do C# tem loss de 0.0045 mas ainda erra a palavra idade, overfitting
data = [
    ([1, 2, 1, 4, 0, 0, 0], 8),    # abad
    ([9, 0, 0, 0, 0, 0, 0], 9),    # i
    ([3, 1, 15, 0, 0, 0, 0], 18),  # cao
    ([21, 22, 1, 0, 0, 0, 0], 44), # uva
    ([1, 0, 0, 0, 0, 0, 0], 1),    # a
    ([18, 15, 21, 16, 1, 0, 0], 71),  # roupa
    ([18, 15, 5, 21, 0, 0, 0], 59),   # roeu
    ([18, 1, 20, 15, 0, 0, 0], 54),   # rato
    ([18, 15, 13, 1, 0, 0, 0], 47),   # roma
    ([18, 5, 9, 0, 0, 0, 0], 32),     # rei
    #([9, 12, 1, 7, 5, 0, 0], 23)      # idade
]

#novo big dataset
data = [
    ([1, 2, 1, 4, 0, 0, 0], 8),    # abad
    ([9, 0, 0, 0, 0, 0, 0], 9),    # i
    ([3, 1, 15, 0, 0, 0, 0], 18),  # cao
    ([21, 22, 1, 0, 0, 0, 0], 44), # uva
    ([1, 0, 0, 0, 0, 0, 0], 1),    # a
    ([18, 15, 21, 16, 1, 0, 0], 71),  # roupa
    ([18, 15, 5, 21, 0, 0, 0], 59),   # roeu
    ([18, 1, 20, 15, 0, 0, 0], 54),   # rato
    ([18, 15, 13, 1, 0, 0, 0], 47),   # roma
    ([18, 5, 9, 0, 0, 0, 0], 32),     # rei
    ([19, 15, 12, 0, 0, 0, 0], 46),     # 'sol'
    ([16, 1, 26, 0, 0, 0, 0], 43),      # 'paz'
    ([18, 9, 15, 0, 0, 0, 0], 42),      # rio'
    ([12, 21, 26, 0, 0, 0, 0], 59),     # 'luz'
    ([1, 18, 0, 0, 0, 0, 0], 19),        # 'ar'
    ([6, 5, 0, 0, 0, 0, 0], 11),         # 'fe'
    ([5, 21, 0, 0, 0, 0, 0], 26),        # 'eu'
    ([3, 1, 19, 1, 0, 0, 0], 24),      # 'casa'
    ([2, 15, 12, 1, 0, 0, 0], 30),     # 'bola'
    ([7, 1, 20, 15, 0, 0, 0], 43),     # 'gato'
    ([12, 9, 22, 18, 15, 0, 0], 76),  # 'livro'
    ([16, 5, 4, 18, 1, 0, 0], 44),    # 'pedra'
    ([2, 1, 14, 1, 14, 1, 0], 33),   # 'banana'
    ([3, 15, 3, 15, 0, 0, 0], 36),     # 'coco'
    ([13, 1, 13, 1, 5, 0, 0], 33),    # 'mamãe'
    ([1, 9, 0, 0, 0, 0, 0], 10),         # 'ai'
    ([15, 9, 0, 0, 0, 0, 0], 24),        # 'oi'
    ([13, 5, 0, 0, 0, 0, 0], 18),        # 'me'
]

X = np.array([x for x, _ in data])  #valores
y = np.array([y for _, y in data])  #labes pontuacao

# Definir o modelo neural,  ativação ReLU
model = models.Sequential([
    layers.Dense(32, activation='relu', input_shape=(7,)),  
    layers.Dense(16, activation='relu'),    #16 neuronios
    layers.Dense(1)
])

# Compilar o modelo ADAM 
model.compile(optimizer='adam', loss='mse')

# Treinar o modelo
history = model.fit(X, y, epochs=1000, verbose=0)

# Avaliar o modelo para uma nova palavra
new_word = np.array([[9, 12, 1, 7, 5, 0, 0]])  # idade
prediction = model.predict(new_word)
print(f"Pontuação prevista para 'idade': {prediction[0][0]}")
