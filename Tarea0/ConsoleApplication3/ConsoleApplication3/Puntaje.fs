module Puntaje

System.Console.Write("¿Quiere activar el bonus?:  \n   Digite 1 y presione Enter si desea hacerlo.\n   Digite 0 y presione Enter si no desea hacerlo.\n   Respuesta:")
let mutable bo =      System.Console.ReadLine()
let mutable bonus = -1
let mutable var1 = 0
try
    bonus <- int bo
with
    | :? System.FormatException -> System.Console.Write("-> Respuesta incorrecta ")
while var1=0 do
    if bonus = -1 || (bonus<> 1 && bonus <> 0 )then
        System.Console.WriteLine("-> Respuesta incorrecta")
        System.Console.Write("¿Quiere activar el bonus?:  \n   Digite 1 y presione Enter si desea hacerlo.\n   Digite 0 y presione Enter si no desea hacerlo.\n   Respuesta:")
        let nu = System.Console.ReadLine() 
        try 
            bonus <- int nu
        with
            | :? System.FormatException -> System.Console.Write("-> Respuesta incorrecta ")

    else if bonus = 1 || bonus = 0 then
        var1 <- 1
done



System.Console.WriteLine("Espere su solución. Cargando...")

let letras1 = "AEIOULNRSTaeioulnrst"
let letras2 = "DGdg"
let letras3 = "BCMPbcmp"
let letras4 = "FHVWYfhvwy"
let letras5 = "Kk"
let letras8 = "JXjx"
let letras10 = "QZqz"
let letras11 = Array.init letras1.Length (fun x -> letras1.[x])
let letras21 = Array.init letras2.Length (fun x -> letras2.[x])
let letras31 = Array.init letras3.Length (fun x -> letras3.[x])
let letras41 = Array.init letras4.Length (fun x -> letras4.[x])
let letras51 = Array.init letras5.Length (fun x -> letras5.[x])
let letras81 = Array.init letras8.Length (fun x -> letras8.[x])
let letras101 = Array.init letras10.Length (fun x -> letras10.[x])


let mutable puntajeTablero = 0;
let mutable puntTot =0;
let guardarPuntajeTotal (punt:int)=
    puntTot <- puntTot + punt
    puntTot

let borrarMarcador (a:int) =
    puntTot <-0 

let  calcularPuntajePalabra2 (palabra:string) =
        let mutable puntaje = 0; 
        let mutable palabraEnCaracteres = Array.init palabra.Length (fun x -> palabra.[x])
        for i in 0..19 do
            for j in 0..palabra.Length-1 do
                if letras11.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+1
        for i in 0..3 do
            for j in 0..palabra.Length-1 do
                if letras21.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+2
        for i in 0..7 do
            for j in 0..palabra.Length-1 do
                if letras31.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+3
        for i in 0..9 do
            for j in 0..palabra.Length-1 do
                if letras41.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+4
        for i in 0..1 do
            for j in 0..palabra.Length-1 do
                if letras51.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+5
        for i in 0..3 do
            for j in 0..palabra.Length-1 do
                if letras81.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+8
        for i in 0..3 do
            for j in 0..palabra.Length-1 do
                if letras101.[i] = palabraEnCaracteres.[j] then
                    puntaje <- puntaje+10
        
        guardarPuntajeTotal puntaje

let  calcularPuntajePalabra (palabra:string) =
    calcularPuntajePalabra2 palabra
