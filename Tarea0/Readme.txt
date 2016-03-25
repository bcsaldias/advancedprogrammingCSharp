El programa está especialmente programado para que pueda poner la mayor 
cantidad de palabras posibles y así alcanzar un mayor puntaje.
Programado para que corra y no se estanque con posibles recursiones.

El bonus está hecho y se pregunta al iniciar el programa si se quiere activar o no.

El tiempo en encontrar solución empieza a correr desde que se le ha entregado los 
datos pedidos al usuario y se ha presionado Enter, entes de eso no busca soluciones.



Sobre mi algoritmo que resuelve el tablero: 

primero pone una palabra raiz y luego intenta meter todas las palabas que quepan unas 5 veces, 
luego de haber metidos en una primera ronda todas las palabras que quepan, desordena el tablero 
y vuelve a intentar meter todas las palabras que quedan, esto unas 3 veces. Luego establece
un tablero y lanza un puntaje total que es comparado con otro tablero que pasa por este mismo proceso
pero al que le llega la misma biblioteca de palabras pero en otro orden, este proceso lo hace 8500 
veces, es decir, crea y compara no menos de 8500 tableros de los cuales nos entrega el mayor valor
encontrado con la lista de palabras. 
Este método no asegura 100% que encontremos la solución óptima pero si nos asegura un tablero muy
cercano al óptimo con no más de un error de alrededor de un 1% a 3% a lo más, 
esto debido a la cantidad de veces que mete las palabras, 
posiblemente al hacer correr 2 o 3 veces el programa nos tire el mismo resultado o umo mayor pero no 
fuera del rango.

Este algoritmo está en el module Program y usa funciones de los demás módulos para mayor orden.


Los supuestos que realicé para este mecanismo:
->	Primero creo que entre más letras libres más palabras puedo poner y por lo tanto más puntaje puedo 
	obtener, por lo tanto la principal restricción para ubica runa palabra en el tablero es que donde se ponga
	esté vacío excepto el casillero indice que es donde intersecta a la palaba anterior, ya que si podía estar
	vacío o ser la misma letra se restan posibilidades de poner más palabras.
-> 	El diccionario está puesto en la carpeta Tarea0 , sin embargo para la revisión es recomendable que 
	el corrector elija el directorio y lo copie el mismo en el programa ya que es algo que depende 
	del equipo en el que se revise. A pesar de lo anterior el programa está diseñado con :
	"..\..\Diccionario de prueba 2.txt"
->	El puntaje por palabra es contado cada vez que se pone una palabra independiente de si una letra está en
	dos palabras, es decir, si pongo la palabra CASA e intersecciona a MALETA en la letra A, el puntaje de esto
	es el puntaje de CASA + el puntaje de MALETA.
-> 	Se asume que como en un diciconario o biblioteca normal las palabras no se repiten.
->	Se asume que la biblitoeca estpa importada como referencia antes de iniciar el programa.
->	Se asume que los directorios en donde se encuentra el diccionario y donde se guarda el tablero final
	son decididos por el usuario ejecutor del programa.
->	Asumí que el tiempo cuenta desde que empieza a buscar la solución hasta que la entrega, por lo que 
	mi programa comienza a buscar la solución cuando dice que ha cargado 0%, carga hasta el 99% y muestra
	el trablero tanto en consola como en el archivo Diccionario de respuesta.txt .
-> 	Supongo que el ayudante agregará como referencia la biblioteca si es que el programa no al lee, ya
	que depende del pc en que se vea. Sin embargo está ubicada y probada para que no sea necesario importarla. 