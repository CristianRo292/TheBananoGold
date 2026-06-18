<img width="511" height="291" alt="portada" src="https://github.com/user-attachments/assets/63428069-7303-431e-9eb3-db139cf9a46a" /> 


# THE BANANO GOLD 2: FUERA DEL OASIS

Executable del juego disponible en: https://drive.google.com/file/d/1jOgqcA-91sTpoCEdbu68AwYt_bERsY0y/view?usp=sharing 

Descripción:
El proyecto de The Banano Gold 2: Fuera del oasis ofrece a los jugadores una experiencia interactiva de plataformas y combate en 2D. Para lograrlo, se implementó una serie de escenas interconectadas que permiten a los usuarios iniciar el juego, explorar diferentes niveles, enfrentarse a enemigos y registrar sus puntuaciones. Todo esto está soportado por un núcleo lógico centralizado de 14 scripts desarrollados en C#. El flujo principal y el control de datos se gestionan mediante un sistema híbrido de controladores. El objeto principal, "IU\_manager\_gamer", centraliza las operaciones críticas del juego para mantener un control absoluto del estado global. Para evitar una saturación y reducir la superficie de riesgo, este sistema se dividió en dos entidades con responsabilidades compartidas: la primera entidad se encarga exclusivamente de la interfaz gráfica y los sonidos, regulando los componentes visuales del Oasis; la segunda entidad controla la lógica interna de los enemigos y el puntaje, asegurando que las reglas de dificultad y las estadísticas se procesen en tiempo real sin interferir con el renderizado.

El juego inicia en una pantalla de menú principal que da la bienvenida al usuario. Al comenzar la partida, el jugador es introducido al mundo del Oasis, el cual se compone de tres niveles secuenciales con mecánicas de dificultad ascendente. En el Nivel 3, el jugador accede a la zona del refrigerador épico, donde se activa el sistema de combate final. Para optimizar el rendimiento y el almacenamiento del juego, se implementaron técnicas avanzadas de reutilización de recursos. En lugar de cargar múltiples fondos pesados, todas las escenas utilizan la misma imagen de fondo mapeada en diferentes alturas y posiciones de cámara, lo que simula la exploración de un entorno tridimensional vasto mientras se mantiene un uso mínimo de memoria de video (VRAM). Asimismo, las transiciones entre cada nivel y las celebraciones de victoria no utilizan paneles individuales redundantes; en su lugar, se diseñó un único "Prefab" modular que contiene animaciones de fuegos artificiales y una imagen dinámica que se actualiza con el número del nivel correspondiente. Este Prefab permanece oculto en la jerarquía, se invoca mediante código al iniciar la escena y se vuelve a ocultar automáticamente tras unos instantes, garantizando consistencia visual y un consumo eficiente de memoria RAM.

La lógica de combate regula el comportamiento de los enemigos distribuidos en el mapa. Los enemigos ejecutan rutinas de movimiento y activan ráfagas de disparo espaciadas por intervalos de tiempo calculados para dar respiro al procesador. El sistema registra las vidas del jugador y acumula los puntos de victoria de manera interna. Para asegurar que el juego mantenga una tasa de cuadros por segundo (FPS) estable en cualquier hardware, el tamaño de la ventana de ejecución se ha configurado de forma fija (Fixed Window), bloqueando el redimensionamiento manual. Esto previene que la interfaz gráfica se desacomode, mantiene la nitidez de los elementos visuales y evita el sobreesfuerzo del procesador al reescalar texturas en tiempo real. Al finalizar los tres niveles, el juego procesa la puntuación total acumulada y redirige al jugador a la pantalla de victoria, consolidando una experiencia fluida, ligera y totalmente autónoma.

# Aspectos Importantes

• **Optimización Extrema de Assets**: Las imágenes y fondos de alta resolución fueron reescalados manualmente mediante herramientas externas antes de ser importados a Unity, y se estandarizó el formato JPG para todos los fondos opacos. Esto eliminó el canal alfa innecesario y redujo drásticamente el peso del build final a solo 45 MB comprimidos, optimizando el tiempo de carga y la tasa de FPS.
• **Modulación Paramétrica de Audio**: En lugar de almacenar múltiples archivos de audio pesados para cada escenario, el juego utiliza una única pista musical base que se modula dinámicamente en cada escena (variando parámetros de tono/pitch y volumen). Esto genera atmósferas sonoras totalmente distintas en cada nivel sin incrementar el peso del ejecutable.
• **Arquitectura de Scripts Compacta**: Se desarrollaron exactamente 14 scripts funcionales con un enfoque híbrido de gestión. Al unificar y luego segmentar las responsabilidades en controladores especializados, se evitó la fragmentación excesiva de la jerarquía de Unity y se eliminaron por completo los errores de referencia nula (`NullReferenceException`).

# Cómo ejecutarlo por primera vez:

Configurar el entorno es muy sencillo. Los requisitos mínimos son una computadora con sistema operativo Windows 10 (compatible incluso con hardware limitado como un procesador Intel Celeron N4020 y 4 GB de RAM) y el descompresor de archivos de tu preferencia. Primero, descarga la carpeta comprimida en formato ZIP del proyecto (`The\_Banano\_Gold\_2.zip`) que posee un peso optimizado de solo 45 MB. Una vez descargada, realiza un clic derecho sobre el archivo y selecciona la opción "Extraer aquí" o extraer en una carpeta dedicada. Una vez extraído el contenido, notarás que la carpeta descomprimida tiene un tamaño aproximado de 125 MB. Para iniciar el videojuego, simplemente accede a la carpeta extraída, busca el archivo ejecutable principal con el nombre `TheBananoGold2.exe` y haz doble clic sobre él. El juego se ejecutará instantáneamente en una ventana fija diseñada para garantizar el máximo rendimiento.

# Tecnologías utilizadas:

• **Unity Engine** (Motor de desarrollo del videojuego y renderizado 2D)
• **C# (C Sharp)** (Lógica de programación, scripts de control y comportamiento de entidades)
• **Programación Orientada a Componentes** (Arquitectura de Prefabs modulares en Unity)
• **Windows Paint** (Herramienta externa utilizada para el pre-procesamiento y reescalado de imágenes)
• **Formatos de Compresión Gráfica (JPG)** (Para optimización de VRAM y almacenamiento)
• **Algoritmos de Modulación de Audio** (Para variación paramétrica de Pitch y Volumen en tiempo real)

# Estructura

• **The Banano Gold 2 (Carpeta Raíz)**

* **TheBananoGold2\_Data (Carpeta)**: Contiene todas las librerías esenciales del motor Unity, recursos compilados, configuraciones de escenas y los datos binarios empaquetados del juego.

  * **StreamingAssets (Subcarpeta)**: Repositorio interno para activos de carga directa si aplica.
  * **sharedassets0.assets**: Archivos de datos unificados que contienen las texturas JPG reescaladas y el clip de audio base.
* **MonoBleedingEdge (Carpeta)**: Entorno de ejecución de código abierto de .NET utilizado por Unity para el soporte y ejecución de los scripts de C#.
* **TheBananoGold2.exe**: Archivo ejecutable principal del videojuego que inicializa el motor, carga el `IU\_manager\_gamer` y arranca la escena del menú principal.
* **UnityPlayer.dll**: Librería dinámica nativa e indispensable para que el motor gráfico procese el juego en el sistema operativo.

