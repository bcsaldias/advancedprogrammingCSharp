module Dibujar

let dibujarMatriz (tableroVacio0:char[,]) (numero:int)=
    let mutable var4 = 0
    let mutable var5 = 0
    while var4<numero do
        var5<-0
        System.Console.Write("\n")
        while var5 < numero do
        if tableroVacio0.[var4,var5] <> ' ' then
            System.Console.Write("[")
            System.Console.Write(tableroVacio0.[var4,var5])
            System.Console.Write("]")
        else
            System.Console.Write("[ ]")
        var5<- var5+1
        done
        var4 <- var4+1
    done