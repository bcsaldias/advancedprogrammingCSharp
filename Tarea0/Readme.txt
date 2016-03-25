El programa est� especialmente programado para que pueda poner la mayor 
cantidad de palabras posibles y as� alcanzar un mayor puntaje.
Programado para que corra y no se estanque con posibles recursiones.

El bonus est� hecho y se pregunta al iniciar el programa si se quiere activar o no.

El tiempo en encontrar soluci�n empieza a correr desde que se le ha entregado los 
datos pedidos al usuario y se ha presionado Enter, entes de eso no busca soluciones.



Sobre mi algoritmo que resuelve el tablero: 

primero pone una palabra raiz y luego intenta meter todas las palabas que quepan unas 5 veces, 
luego de haber metidos en una primera ronda todas las palabras que quepan, desordena el tablero 
y vuelve a intentar meter todas las palabras que quedan, esto unas 3 veces. Luego establece
un tablero y lanza un puntaje total que es comparado con otro tablero que pasa por este mismo proceso
pero al que le llega la misma biblioteca de palabras pero en otro orden, este proceso lo hace 8500 
veces, es decir, crea y compara no menos de 8500 tableros de los cuales nos entrega el mayor valor
encontrado con la lista de palabras. 
Este m�todo no asegura 100% que encontremos la soluci�n �ptima pero si nos asegura un tablero muy
cercano al �ptimo con no m�s de un error de alrededor de un 1% a 3% a lo m�s, 
esto debido a la cantidad de veces que mete las palabras, 
posiblemente al hacer correr 2 o 3 veces el programa nos tire el mismo resultado o umo mayor pero no 
fuera del rango.

Este algoritmo est� en el module Program y usa funciones de los dem�s m�dulos para mayor orden.


Los supuestos que realic� para este mecanismo:
->	Primero creo que entre m�s letras libres m�s palabras puedo poner y por lo tanto m�s puntaje puedo 
	obtener, por lo tanto la principal restricci�n para ubica runa palabra en el tablero es que donde se ponga
	est� vac�o excepto el casillero indice que es donde intersecta a la palaba anterior, ya que si pod�a estar
	vac�o o ser la misma letra se restan posibilidades de poner m�s palabras.
-> 	El diccionario est� puesto en la carpeta Tarea0 , sin embargo para la revisi�n es recomendable que 
	el corrector elija el directorio y lo copie el mismo en el programa ya que es algo que depende 
	del equipo en el que se revise. A pesar de lo anterior el programa est� dise�ado con :
	"..\..\Diccionario de prueba 2.txt"
->	El puntaje por palabra es contado cada vez que se pone una palabra independiente de si una letra est� en
	dos palabras, es decir, si pongo la palabra CASA e intersecciona a MALETA en la letra A, el puntaje de esto
	es el puntaje de CASA + el puntaje de MALETA.
-> 	Se asume que como en un diciconario o biblioteca normal las palabras no se repiten.
->	Se asume que la biblitoeca estpa importada como referencia antes de iniciar el programa.
->	Se asume que los directorios en donde se encuentra el diccionario y donde se guarda el tablero final
	son decididos por el usuario ejecutor del programa.
->	Asum� que el tiempo cuenta desde que empieza a buscar la soluci�n hasta que la entrega, por lo que 
	mi programa comienza a buscar la soluci�n cuando dice que ha cargado 0%, carga hasta el 99% y muestra
	el trablero tanto en consola como en el archivo Diccionario de respuesta.txt .
-> 	Supongo que el ayudante agregar� como referencia la biblioteca si es que el programa no al lee, ya
	que depende del pc en que se vea. Sin embargo est� ubicada y probada para que no sea necesario importarla. 