import numpy as np
import tensorflow as tf
from tensorflow.keras import layers, models

data = [
    ([1, 2, 1, 4, 0, 0, 0], 8),    # abad
    ([3, 1, 15, 0, 0, 0, 0], 18),  # cao
    ([21, 22, 1, 0, 0, 0, 0], 44), # uva
    ([1, 0, 0, 0, 0, 0, 0], 1),    # a
    ([18, 15, 21, 16, 1, 0, 0], 71),  # roupa
    ([18, 15, 5, 21, 0, 0, 0], 59),   # roeu
    ([18, 1, 20, 15, 0, 0, 0], 54),   # rato
    ([18, 15, 13, 1, 0, 0, 0], 47),   # roma
    ([18, 5, 9, 0, 0, 0, 0], 32),     # rei
    ([9, 12, 1, 7, 5, 0, 0], 23)      # idade
]

# Separar entradas (features) e saídas (labels)
X = np.array([x for x, _ in data])
y = np.array([y for _, y in data])

# Definir o modelo de regressão
model = models.Sequential([
    layers.Dense(64, activation='relu', input_shape=(7,)),  
    layers.Dense(32, activation='relu'),
    layers.Dense(1)
])

# Compilar o modelo
model.compile(optimizer='adam', loss='mse')

# Treinar o modelo
history = model.fit(X, y, epochs=400, verbose=0)

# Avaliar o modelo para uma nova palavra
new_word = np.array([[9, 12, 1, 7, 5, 0, 0]])  # idade
prediction = model.predict(new_word)
print(f"Pontuação prevista para 'idade': {prediction[0][0]}")
