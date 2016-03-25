module Tablero
open BibliotecaT0.BT0
open Puntaje

let calculaPosiciones (palabra:char[]) (palabra2:char[])=
        let mutable indiceI = 0;
        let mutable indiceJ = 0;
        let mutable iI = 0;
        let mutable iJ=0;
        for i in 0..palabra.Length-1 do
            let mutable indiceI = 0;
            let mutable indiceJ = 0;
            let mutable var2 = 0;
            let mutable var3 = 0;
            if palabra <> palabra2 then
                for j in 0..palabra2.Length-1 do
                    let char2 = System.Char.ToLower(palabra2.[j])
                    if palabra.[i] = palabra2.[j] then
                        if i>indiceI then
                            indiceI <-i
                            indiceJ <- j
                    else if palabra.[i]=char2 then
                        if i>indiceI then
                            indiceI <-i
                            indiceJ <- j
            iI<- indiceI
            iJ<- indiceJ
        iI,iJ


let ponerPalabraParada (palabra:string) (fila:int) (columna:int) (tablero:char[,]) (numero:int)= 
    let mutable palabraEnCaracteres = Array.init palabra.Length (fun x -> palabra.[x])
    let pEnC = palabraEnCaracteres.[0..palabraEnCaracteres.Length-1]
    let mutable v3 = 0;
    while v3<pEnC.Length do
       tablero.[fila+v3, columna] <- pEnC.[v3]
       if bonus = 1 && ((fila+v3= 0 && columna= 0)||(fila+v3=numero-1  && columna=numero-1 )||(fila+v3=numero/2  && columna=numero/2 )|| (fila+v3=0 && columna=numero/2 )||(fila+v3=0  && columna=numero-1 )|| (fila+v3=numero/2  && columna=0 )|| (fila+v3=numero/2  && columna=numero-1 ) || (fila+v3=numero-1  && columna= 0)||(fila+v3=numero-1  && columna=numero/2 )) then
        calcularPuntajePalabra palabra
        v3 <- v3
       v3<-v3+1
    done



let ponerPalabraAcostada (palabra:string) (fila:int) (columna:int) (tablero:char[,]) (numero:int) = 
    let mutable palabraEnCaracteres = Array.init palabra.Length (fun x -> palabra.[x])
    let pEnC = palabraEnCaracteres.[0..palabraEnCaracteres.Length-1]
    let mutable v3 = 0;
    while v3<pEnC.Length do
        tablero.[fila, columna+v3] <- pEnC.[v3]
        if bonus = 1 && ((fila= 0 && columna+v3= 0)||(fila=numero-1  && columna+v3=numero-1 )||(fila=numero/2  && columna+v3=numero/2 )|| (fila=0 && columna+v3=numero/2 )||(fila=0  && columna+v3=numero-1 )|| (fila=numero/2  && columna+v3=0 )|| (fila=numero/2  && columna+v3=numero-1 ) || (fila=numero-1  && columna+v3= 0)||(fila=numero-1  && columna+v3=numero/2 )) then
            calcularPuntajePalabra palabra
            v3 <- v3
        v3 <- v3+1
    done

let intentarPoner (iJ:int) (ka:int) (iI:int) (palabra2:string) (tablero:char[,]) (numero:int) (b:int)=
   let mutable seguirOno = 0
   let mutable ponerPrim = true;
   let mutable ponerPrim2 = true;
   let mutable puesto = 0;
   
   if iI <= numero && iI>=0&&iJ-ka>=0 && iJ-ka<=numero && iJ>=0 && iJ<=numero && iJ>=0 && iJ<=numero && iJ+palabra2.Length-ka>=0  && iJ+palabra2.Length-ka<=numero && iJ+palabra2.Length-ka>=0 && iJ+palabra2.Length-ka<=numero && iJ+palabra2.Length-ka<=numero && iJ+palabra2.Length-ka>=0 then
    if iI = 0  then 
     for h in iJ-ka..iJ-1 do
        if tablero.[iI,h] <> ' '||tablero.[iI+1,h]<>' 'then
            ponerPrim <- false;
     for h in iJ+1..iJ+palabra2.Length-ka-1 do
        if tablero.[iI,h] <> ' ' ||tablero.[iI+1,h]<>' ' then
            ponerPrim2 <- false;
     if seguirOno=0&& ponerPrim = true && ponerPrim2 = true && palabra2.Length<=numero && (iJ-ka=0 ||tablero.[iI,iJ-ka-1]=' ' ) && (iJ+palabra2.Length-ka=numero ||tablero.[iI,iJ+palabra2.Length-ka]=' ') then
        let J = iJ-ka
        if seguirOno = 0 then
            ponerPalabraAcostada palabra2 iI J tablero numero
        puesto <- 1
        calcularPuntajePalabra palabra2
        seguirOno <- 1
    else if iI = numero || iI = numero-1 then
     for h in iJ-ka..iJ-1 do
        if tablero.[iI,h] <> ' '||tablero.[iI-1,h]<>' 'then
            ponerPrim <- false;
     for h in iJ+1..iJ+palabra2.Length-ka-1 do
        if tablero.[iI,h] <> ' ' ||tablero.[iI-1,h]<>' ' then
            ponerPrim2 <- false;
     if seguirOno=0&& ponerPrim = true && ponerPrim2 = true && palabra2.Length<=numero && (iJ-ka=0 || tablero.[iI,iJ-ka-1]=' ' ) && (iJ+palabra2.Length-ka=numero || tablero.[iI,iJ+palabra2.Length-ka]=' ') then
        let J = iJ-ka
        if seguirOno = 0 then
            ponerPalabraAcostada palabra2 iI J tablero numero
        puesto <- 1
        calcularPuntajePalabra palabra2
        seguirOno <- 1
    else
     for h in iJ-ka..iJ-1 do
        if tablero.[iI,h] <> ' '||tablero.[iI+1,h]<>' '||tablero.[iI-1,h]<>' '  then
            ponerPrim <- false;
     for h in iJ+1..iJ+palabra2.Length-ka-1 do
        if tablero.[iI,h] <> ' ' ||tablero.[iI+1,h]<>' '||tablero.[iI-1,h]<>' ' then
            ponerPrim2 <- false;
     if seguirOno=0&& ponerPrim = true && ponerPrim2 = true && palabra2.Length<=numero  && (iJ-ka=0 || tablero.[iI,iJ-ka-1]=' ' ) && (iJ+palabra2.Length-ka=numero || tablero.[iI,iJ+palabra2.Length-ka]=' ')then
        let J = iJ-ka
        if seguirOno = 0 then
            ponerPalabraAcostada palabra2 iI J tablero numero
        puesto <- 1
        calcularPuntajePalabra palabra2
        seguirOno <- 1

   let mutable ponerPrim3 = true;
   let mutable ponerPrim4 = true;

   if iI<= numero && iI>=0 then
        //  if iI <= numero && iI>=0&&iJ-ka>=0 && iJ-ka<=numero && iJ>=0 && iJ<=numero && iJ>=0 && iJ<=numero && iJ+palabra2.Length-ka>=0  && iJ+palabra2.Length-ka<=numero && iJ+palabra2.Length-ka>=0 && iJ+palabra2.Length-ka<=numero && iJ+palabra2.Length-ka<=numero && iJ+palabra2.Length-ka>=0 then
    
    if puesto <> 1&& iI>=0 && iI<=numero && iI-ka>=0 && iI-ka<=numero && iI>=0 && iI>=0 && iI+palabra2.Length-ka>=0  && iI+palabra2.Length-ka<=numero && iI+palabra2.Length-ka>=0 && iI+palabra2.Length-ka<=numero && iI+palabra2.Length-ka<=numero && iI+palabra2.Length-ka>=0 then
       if iJ = 0  then 
        for h in iI-ka..iI-1 do
            if tablero.[h,iJ] <> ' '||tablero.[h,iJ+1]<>' 'then
                ponerPrim3 <- false;
        for h in iI+1..iI+palabra2.Length-ka-1 do
            if tablero.[h,iJ] <> ' ' ||tablero.[h,iJ+1]<>' ' then
                ponerPrim4 <- false;
        if seguirOno=0&& ponerPrim3 = true && ponerPrim4 = true && palabra2.Length<=numero  && (iI-ka=0 || tablero.[iI-ka-1,iJ]=' ' ) &&  (iI+palabra2.Length-ka=numero || tablero.[iI+palabra2.Length-ka,iJ]=' '  )then
            let I = iI-ka
            if seguirOno = 0 then
                ponerPalabraParada palabra2 I iJ tablero numero
            puesto <- 1
            calcularPuntajePalabra palabra2
            seguirOno <- 1

       else if iJ = numero-1 || iJ= numero then
        for h in iI-ka..iI-1 do
            if tablero.[h,iJ] <> ' '||tablero.[h,iJ-1]<>' 'then
                ponerPrim3 <- false;
        for h in iI+1..iI+palabra2.Length-ka-1 do
            if tablero.[h,iJ] <> ' ' ||tablero.[h,iJ-1]<>' ' then
                ponerPrim4 <- false;
        if seguirOno=0&& ponerPrim3 = true && ponerPrim4 = true && palabra2.Length<=numero  && (iI-ka=0 || tablero.[iI-ka-1,iJ]=' ' )  && (iI+palabra2.Length-ka=numero || tablero.[iI+palabra2.Length-ka,iJ]=' '  ) then
            let I = iI-ka
            if seguirOno = 0 then
                ponerPalabraParada palabra2 I iJ tablero numero
            puesto <- 1
            calcularPuntajePalabra palabra2
            seguirOno <- 1

       else
        for h in iI-ka..iI-1 do
            if tablero.[h,iJ] <> ' ' ||tablero.[h,iJ+1]<>' '||tablero.[h,iJ-1]<>' 'then
                ponerPrim3 <- false;

        for h in iI+1..iI+palabra2.Length-ka-1 do
            if tablero.[h,iJ] <> ' '||tablero.[h,iJ+1]<>' '||tablero.[h,iJ-1]<>' 'then
                ponerPrim4 <- false;

        if seguirOno = 0&& ponerPrim3 = true && ponerPrim4 = true && palabra2.Length<=numero  && (iI-ka=0 || tablero.[iI-ka-1,iJ]=' ' ) && (iI+palabra2.Length-ka=numero || tablero.[iI+palabra2.Length-ka,iJ]=' '  ) then //&& tablero.[iI+palabra2.Length-ka+2,iJ]=' ' && tablero.[iI+palabra2.Length-ka+1,iJ]=' '  then
            let I = iI-ka
            if seguirOno = 0 then
                ponerPalabraParada palabra2 I iJ tablero numero
            puesto <- 1
            calcularPuntajePalabra palabra2
            seguirOno <- 1


   seguirOno



let ponerPalabra (palabra2:string) (numero:int) (tablero:char[,]) (b:int) =
   let mutable indiceI = 0;
   let mutable indiceJ = 0;
   let mutable char = ' ';
   let mutable chars = ' ';
   let mutable iI = 0;
   let mutable iJ=0;
   let mutable ka = 0;
   let mutable noMas = 0;

   for k in 0..palabra2.Length-1 do
    if noMas =0 then
        noMas <- 0;
        let puestaoNo = 0;
        for i in 0..numero-1 do
            for j in 0..numero-1 do
                    if palabra2.[k] = tablero.[i,j] && noMas =0 then
                                    indiceI <-i
                                    indiceJ <- j
                                    char<- palabra2.[k]
                                    chars<-tablero.[i,j]
                                    ka<-k
                                    iI<- indiceI
                                    iJ<- indiceJ
                                    if intentarPoner iJ ka iI palabra2 tablero numero b = 1 then
                                        noMas <- 1
                                    

                    else if  palabra2.[k]=System.Char.ToLower(tablero.[i,j]) && noMas = 0 then
                                    indiceI <-i
                                    indiceJ <- j
                                    char<- palabra2.[k]
                                    chars<-tablero.[i,j]
                                    ka<-k
                                    iI<- indiceI
                                    iJ<- indiceJ
                                    if intentarPoner iJ ka iI palabra2 tablero numero b = 1 then
                                        noMas <- 1
   noMas
   

