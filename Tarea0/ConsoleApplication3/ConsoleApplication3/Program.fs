// Más información acerca de F# en http://fsharp.net

module Program
open BibliotecaT0.BT0
open Puntaje
open Dibujar
open Tablero

System.Console.Write("Ingrese un número impar para determinar el largo y ancho del tablero\nLuego presione Enter. Número:")
let mutable name =      System.Console.ReadLine()
let arreNem = Array.init name.Length (fun x -> name.[x])
let mutable numero = 0;
try 
    numero <- int name 
 
with
    | :? System.FormatException -> System.Console.Write("-> No es un entero ")


let mutable var1 = 0

while var1=0 do
    if numero%2=0 then
        System.Console.WriteLine("-> Medida incorrecta")
        System.Console.Write("Ingrese un número impar para determinar el largo y ancho del tablero:\nLuego presione Enter. Número:")
        name <- System.Console.ReadLine()
        try 
            numero <- int name 
 
        with
            | :? System.FormatException -> System.Console.Write("-> No es un entero ")


    else
        System.Console.Write("La dimensión de su tablero es " + name + "x" + name + "\n\n\n")
        var1 <- 1
done

let mutable comprobarPimeraPal = 0;
let diccionario = LeerDiccionario("..\..\Diccionario de prueba 2.txt")
let mutable tablero = Array.init diccionario.Length (fun x ->(diccionario.[x]))
let mutable tableroVacio0 = Array2D.zeroCreate<char> numero numero
let numDiv2 = numero/2

let mutable tableroDeComp = Array2D.zeroCreate<char> numero numero
let guardarNuevoTablero (a:int) = 
 let mutable var6=0
 let mutable var7=0
 while var6<numero do
        var7 <-0
        while var7<numero do
                    tableroDeComp.[var6,var7] <- tableroVacio0.[var6, var7]
                    var7 <- var7+1
        done
        var6 <-var6+1
 done

let mutable pp = 0
let mutable co =0
let guardarNuevoPuntaje (p:int)=
    if p>pp then
        pp <- p
        guardarNuevoTablero 0
    
    co<-co+1

    if co%85 = 0 then
        let a = co/85
        System.Console.Clear()
        System.Console.Write("La dimensión de su tablero es " + name + "x" + name + "\n\n\n")
        System.Console.Write("Espere su solución. Cargando...")
        printf " Porcentaje de Carga %A" a
    pp

let imprPuntajeFinal (a:int)=
    printfn "\n\n Puntaje del Tablero :  %A" (guardarNuevoPuntaje 0)
 


let desordenarTablero (tablero:string[])= 
  for i in 0..4 do
    let mutable cont =0
    let generator = System.Random()
    let rollDie() = generator.Next(tablero.Length-1)
    let mutable result = rollDie()
    for u in 0..tablero.Length*tablero.Length do
     while cont < tablero.Length do
        let generator = System.Random()
        result <- rollDie()
        while result = cont do
            let generator = System.Random()
            result <- rollDie()
        done
        let palabraAinterc = tablero.[result]
        tablero.[result] <- tablero.[cont]
        tablero.[cont] <- palabraAinterc
        cont<-cont+1
     done
  tablero

for y in 0..8500 do
 let mutable var6=0
 let mutable var7=0
 while var6<numero do
        var7 <-0
        while var7<numero do
                    tableroVacio0.[var6, var7] <- ' '
                    var7 <- var7+1
        done
        var6 <-var6+1
 done 
 let mutable b = 0
 let tableroAux = Array.init diccionario.Length (fun x ->(diccionario.[x])) // arreglo de palabras

 let comenzar (tablero:string[]) = 
  let mutable b = 0   
  for b in 0..tablero.Length-1 do
    if b <tablero.Length then
        let mutable indiceI = 0;
        let mutable indiceJ = 0;
        let mutable var2 = 0;
        let mutable var3 = 0;
        let mutable palabraEnCaracteres = Array.init tableroAux.[b].Length (fun x -> tableroAux.[b].[x])
        let pEnC = palabraEnCaracteres.[0..palabraEnCaracteres.Length-1]
        let mutable palabRaiz= 0;
        if tableroVacio0.[numDiv2,numDiv2]= ' ' && pEnC.Length<=numero then
        //printfn "%A" pEnC
            while var3<pEnC.Length do
                tableroVacio0.[(numero-pEnC.Length)/2+var3, numDiv2] <- pEnC.[var3]
                if bonus = 1 && (((numero-pEnC.Length)/2+var3= 0)||(numero-pEnC.Length)/2+var3=numero-1||((numero-pEnC.Length)/2+var3=numero/2 ) )then
                    calcularPuntajePalabra tableroAux.[b]
                    var3 <- var3
                var3 <- var3+1
            done
            calcularPuntajePalabra tableroAux.[b]
            tableroAux.[b] <- "\n0"
            
            palabRaiz <-palabraEnCaracteres.Length;
        let c = b+1
        if ponerPalabra tablero.[b] numero tableroVacio0 b = 1 then
                tableroAux.[b] <- "\n0"
 
 
 let mutable iu = 0;
 while iu < 5 do
    comenzar (desordenarTablero tableroAux)
    iu<-iu+1
 done
 guardarNuevoPuntaje (guardarPuntajeTotal 0)
 borrarMarcador 0

imprPuntajeFinal 0
dibujarMatriz tableroDeComp numero


EscribirTablero2("..\..\Diccionario de respuesta.txt", tableroDeComp)
System.Console.ReadKey(true)
