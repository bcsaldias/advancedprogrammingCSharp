-Con respecto a los atauqe especiales de cada uno, Ataque dorado, 
ataque plateado y ataque de bronce, cre� solo Ataque() que es virtual
y as� cada uno ataca de la forma que corresponde si es q no especifico
el tipo de caballero, aprovecho el polimorfismo.
-Los turnos del caballero de oro los decid� de cuando le tocaba atacar, es decir,
si le toca atacar y NO ataca , entonces ah� pas� un turno que no atac�, aunque entre medio
el rival haya atacado 2 o 3 veces.
-Mhu resucita pero no necesariamente sigue peliando �l, resucita todas las veces que quiera
si es que la probabilidad est� a su favor cuando muere.
-El modo de control de flujo es el especificado en el enunciado, el bot�n de la flecha
derecha, cada acci�n comprende un ataque o 2 usos de habilidades, y la acci�n comprende varias
consecuencias por los que habitualmente de una acci�n habr� m�s de un resultado.
-La victoria la consider� como victoria total, por lo que no se celebra cuando los caballeros
logran pasar a la siguiente casa, sino que se muestra si el caballero de oro  los dej� pasar o si
muere, sin embargo como consider� como victoria el resultado final, se muestra al final de la simulaci�n
el ganador de la batalla de las 12 casas.
-Para los items armadura y arma no encontr� necesario crear una clase item por lo que las us� por separado
ya que no utilizar�a el casting ni polimorfismo.
-Hice una clase simulaci�n donde sucede todo el control de flujo.
-No s� para qu� sirven las constelaciones jaja :D 
-El numero m�ximo de las caracter�sticas que aumentan en el transcurso del tiempo lo dej� ilimitado, 
excepto el de conciencia que no puede ser m�s de 100 ni menos de 0, igual que la probabilidad de acci�n.
-Consider� las variables como int ya que as� la interacci�n con el usuario es m�s clara y se puede
tener mejor referencia de las variaciones, y no estar pendiende de los decimales que al fin y al cabo
para este fin no son fundamentales.
-solo si llega un caballero de plata a atacar lo creo, si no llega es null.
- a veces los generadores aleatorios no funcionan bien, lo escribo porque existe la posibilidad de que
se pegue un rato, sin embargo est� programado para que rinda lo mejor posible.

-en cada batalla existen tipos de peleas, ya est� peliando un caballero de oro contra un plata o contra
un bronce, la Pelea como tal es en la de los ataques directos llamado Ataque, ya sea el dorado, el plateado
o el de bronce.
- en el caso de pelea contra Mhu que es de oro, se agrega la acci�n de si es �l o no , todo lo dem�s 
transucrre normal.
- la probabilidad de acci�n o inacci�n de un oro est� determinada sobre la opci�n de si le toca realizar
alguna habilidad o no, consider� cada habilidad del oro como un ataque, por lo que calcula la probabilidad
sobre el hecho de si le toca o no actuar.
-Para hacer m�s equilibrado el juego y que no siempre ganen los oros ni siempre ganen los bronce, me reg� por
que el m�s r�pido actue primero pero el m�s lento puede actuar 2 veces seguidas despu�s de este siempre y
cuando sea una batalla del tipo PELEA , si no es de este tipo todo se deja a la probabilidad.
-Manej� juntas las habilidades de predicar por zahoii y pensar en zahori del caballero de brone para
que la batalla andubiera m�s r�pido.
- consider� importante todas las habilidades ya que por ejemplo si el caballero de oro tiene menos
probabilidad de atacarme y aumento mi cosmos entonces tengo m�s posiblidades de ganarle como caballero 
de bronce o plata.
- en esta tarea no us� getter y setter ya que el profesor explicit� que no era necesario para esta tarea.