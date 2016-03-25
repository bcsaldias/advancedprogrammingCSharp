-Con respecto a los atauqe especiales de cada uno, Ataque dorado, 
ataque plateado y ataque de bronce, creé solo Ataque() que es virtual
y así cada uno ataca de la forma que corresponde si es q no especifico
el tipo de caballero, aprovecho el polimorfismo.
-Los turnos del caballero de oro los decidí de cuando le tocaba atacar, es decir,
si le toca atacar y NO ataca , entonces ahí pasó un turno que no atacó, aunque entre medio
el rival haya atacado 2 o 3 veces.
-Mhu resucita pero no necesariamente sigue peliando él, resucita todas las veces que quiera
si es que la probabilidad está a su favor cuando muere.
-El modo de control de flujo es el especificado en el enunciado, el botón de la flecha
derecha, cada acción comprende un ataque o 2 usos de habilidades, y la acción comprende varias
consecuencias por los que habitualmente de una acción habrá más de un resultado.
-La victoria la consideré como victoria total, por lo que no se celebra cuando los caballeros
logran pasar a la siguiente casa, sino que se muestra si el caballero de oro  los dejó pasar o si
muere, sin embargo como consideré como victoria el resultado final, se muestra al final de la simulación
el ganador de la batalla de las 12 casas.
-Para los items armadura y arma no encontré necesario crear una clase item por lo que las usé por separado
ya que no utilizaría el casting ni polimorfismo.
-Hice una clase simulación donde sucede todo el control de flujo.
-No sé para qué sirven las constelaciones jaja :D 
-El numero máximo de las características que aumentan en el transcurso del tiempo lo dejé ilimitado, 
excepto el de conciencia que no puede ser más de 100 ni menos de 0, igual que la probabilidad de acción.
-Consideré las variables como int ya que así la interacción con el usuario es más clara y se puede
tener mejor referencia de las variaciones, y no estar pendiende de los decimales que al fin y al cabo
para este fin no son fundamentales.
-solo si llega un caballero de plata a atacar lo creo, si no llega es null.
- a veces los generadores aleatorios no funcionan bien, lo escribo porque existe la posibilidad de que
se pegue un rato, sin embargo está programado para que rinda lo mejor posible.

-en cada batalla existen tipos de peleas, ya esté peliando un caballero de oro contra un plata o contra
un bronce, la Pelea como tal es en la de los ataques directos llamado Ataque, ya sea el dorado, el plateado
o el de bronce.
- en el caso de pelea contra Mhu que es de oro, se agrega la acción de si es él o no , todo lo demás 
transucrre normal.
- la probabilidad de acción o inacción de un oro está determinada sobre la opción de si le toca realizar
alguna habilidad o no, consideré cada habilidad del oro como un ataque, por lo que calcula la probabilidad
sobre el hecho de si le toca o no actuar.
-Para hacer más equilibrado el juego y que no siempre ganen los oros ni siempre ganen los bronce, me regí por
que el más rápido actue primero pero el más lento puede actuar 2 veces seguidas después de este siempre y
cuando sea una batalla del tipo PELEA , si no es de este tipo todo se deja a la probabilidad.
-Manejé juntas las habilidades de predicar por zahoii y pensar en zahori del caballero de brone para
que la batalla andubiera más rápido.
- consideré importante todas las habilidades ya que por ejemplo si el caballero de oro tiene menos
probabilidad de atacarme y aumento mi cosmos entonces tengo más posiblidades de ganarle como caballero 
de bronce o plata.
- en esta tarea no usé getter y setter ya que el profesor explicitó que no era necesario para esta tarea.