using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication2
{
    public class Simulacion
    {

        Random r = new Random();
        public Mhu mhu;
        public CaBronce[] cBronces = new CaBronce[5];
        public CaOro[] cOros = new CaOro[12];
        public Casa[] ListaCasas = new Casa[12];
        public int contadorDeCasa = 0;
        public void Comenzar(){
        cBronces[0] = new CaBronce("Bronce1", "Constelación1");
        cBronces[1] = new CaBronce("Bronce2", "Constelación2");
        cBronces[2] = new CaBronce("Bronce3", "Constelación3");
        cBronces[3] = new Ikki();
        cBronces[4] = new Seiya();

        cOros[0] = new CaOro("Oro1");
        cOros[1] = new CaOro("Oro2");
        cOros[2] = new CaOro("Oro3");
        cOros[3] = new CaOro("Oro4");
        cOros[4] = new CaOro("Oro5");
        cOros[5] = new CaOro("Oro6");
        cOros[6] = new CaOro("Oro7");
        cOros[7] = new CaOro("Oro8");
        cOros[8] = new CaOro("Oro9");
        cOros[9] = new CaOro("Oro10");
        cOros[10] = new CaOro("Oro11");
        
        mhu= new Mhu();
        cOros[11] = mhu;

        int casaMhu = r.Next(4, 9);

        ListaCasas[casaMhu - 1] = new Casa(casaMhu - 1, cOros[11]);

        int j = 0;
        for (int i = 0; i < ListaCasas.Length; i++)
            {
                if (i != casaMhu-1)
                {
                    ListaCasas[i] = new Casa(i, cOros[j]);
                    j++;
                }
            }

        irANuevaCasa(contadorDeCasa);

        }


        public void irANuevaCasa(int nuCasa)
        {

            if (contadorDeCasa < 12)
            {
                CaPlata nuevo = null;
                nuevo = GenerarCaballeroPlata();
                ListaCasas[contadorDeCasa].recibirCaballeros(nuevo);
                CaBronce primero = Otro();
                if (ListaCasas[contadorDeCasa].hayPlata != null && puedenPelear(ListaCasas[contadorDeCasa].albergado, ListaCasas[contadorDeCasa].hayPlata))
                {
                    while (contadorDeCasa < 12 && puedenPelear(ListaCasas[contadorDeCasa].albergado, ListaCasas[contadorDeCasa].hayPlata))
                    {
                        PeleaCotraPlata(ListaCasas[contadorDeCasa].albergado, ListaCasas[contadorDeCasa].hayPlata);

                    }
                    if (contadorDeCasa < 12 && ListaCasas[contadorDeCasa].albergado.Vida > 0)
                    {
                        ListaCasas[contadorDeCasa].albergado.Cosmos = ListaCasas[contadorDeCasa].albergado.cInicial;
                        primero.Cosmos = primero.cInicial;
                        primero.amorAZahori = primero.amorZaho0;
                        PeleaCotraBronce(ListaCasas[contadorDeCasa].albergado, primero);

                    }
                    else
                    {
                        contadorDeCasa++;
                        irANuevaCasa(contadorDeCasa);

                    }
                }
                else
                {
                    PeleaCotraBronce(ListaCasas[contadorDeCasa].albergado, primero);

                }

            }

        }


        public void PeleaCotraPlata(CaOro C1, CaPlata C2) 
        {
            if (C2 != null)
            {
                Random ru = new Random();
                int tipoPelea = ru.Next(0, 7);
                if (tipoPelea < 2)
                {int actuara = r.Next(0, 100);

                    if (actuara < C1.probAccion)
                    {
                     C1.turnosNoActuados = 0;
                     Pelea(C1, C2);

                    }
                }
                else if (tipoPelea == 2)
                {
                    C2.incrementarCosmos();

                }
                else if (tipoPelea == 3)
                {
                    int actuara = r.Next(0, 100);

                    if (actuara < C1.probAccion)
                    {
                        C1.turnosNoActuados = 0;
                        C1.incrementarCosmos();

                    }
                    else
                    {
                       
                        if (C1.turnosNoActuados > 1)
                        {
                            Console.ReadKey();
                            Console.WriteLine("\nEl caballeo de oro " + C1.Nombre + " ha pasado 2 turnos sin atacar por lo que deja pasar a la siguiente casa");
                            contadorDeCasa++;
                            irANuevaCasa(contadorDeCasa);
                              

                        }

                    }

                }
                else if (tipoPelea > 3 && ReferenceEquals(C1, mhu))
                {
                    int actuara = r.Next(0, 100);

                    if (actuara < C1.probAccion)
                    {
                        C1.turnosNoActuados = 0;
                        mhu.Regeneracion(cBronces);

                        contadorDeCasa++;
                        irANuevaCasa(contadorDeCasa);
                    }
                    else
                    {


                        if (C1.turnosNoActuados > 1)
                        {

                            Console.ReadKey();
                            Console.WriteLine("\nEl caballeo de oro " + C1.Nombre + " ha pasado 2 turnos sin atacar por lo que deja pasar a la siguiente casa");
                            contadorDeCasa++;
                            irANuevaCasa(contadorDeCasa);
                            

                        }
                    }


                }
            }
        }

        public CaBronce Otro()
        {
            int hayMas = 0;
            for(int y = 0; y<5;y++){
                if (cBronces[y].Vida >0)
                {
                hayMas=1;
                }
            }
            if (hayMas == 1)
            {
                Random j = new Random(DateTime.Now.Second);
                Thread.Sleep(30);
                int nC = j.Next(0, 5);
                CaBronce a = cBronces[nC];
                while (a.Vida <= 0)
                {
                    a = cBronces[j.Next(0, 5)];

                }
                return a;
            }

            return null;
            
        }

        public void PeleaCotraBronce(CaOro C1, CaBronce C2)
        {
            if (C1.turnosNoActuados > 1)
            {
                Console.ReadKey();
                Console.WriteLine("\nEl caballeo de oro " + C1.Nombre + " ha pasado 2 turnos sin atacar por lo que deja pasar a la siguiente casa");
                contadorDeCasa++;
                irANuevaCasa(contadorDeCasa);
                  
    
            }

            bool pelea = true;
            if (puedenPelear(C1, C2) && pelea == true)
            {
                while (puedenPelear(C1, C2))
                {

                    int tipoPelea = r.Next(0, 6);
                 
                    if (tipoPelea <2)
                    {
                        int actuara = r.Next(0, 100);

                        if (actuara < C1.probAccion)
                        {
                            C1.turnosNoActuados = 0;
                            Pelea(C1, C2);
                        }

                    }
                    else if (tipoPelea <3)
                    {
                        C2.pensarEnZahori();
                        C2.predicarPorZahori(C1);

                    }
                    else if (tipoPelea <4)
                    {
                        C2.incrementarCosmos();

                    }
                    else if (tipoPelea <5)
                    {
                        Random ra = new Random();
                        int actuara = ra.Next(0, 100);

                        if (actuara < C1.probAccion)
                        {
                            C1.turnosNoActuados = 0;
                            C1.incrementarCosmos();

                        }
                        else
                        {
                            if (C1.turnosNoActuados > 1)
                            {
                                Console.ReadKey();
                                Console.WriteLine("\nEl caballeo de oro " + C1.Nombre + " ha pasado 2 turnos sin atacar por lo que deja pasar a la siguiente casa");
                                contadorDeCasa++;
                                irANuevaCasa(contadorDeCasa);
                      

                            }
                        }

                    }
                    else
                    {
                        C2.ejecucionDeAthena(C1);

                    }
         
                }

                if (C1.Vida <= 0)
                {
                    contadorDeCasa++;

                    irANuevaCasa(contadorDeCasa);

                }
                else if (C2.Vida <= 0)
                {
                    CaBronce u = Otro();
                    if (u != null && contadorDeCasa < 12)
                    {
                        ListaCasas[contadorDeCasa].albergado.Cosmos = ListaCasas[contadorDeCasa].albergado.cInicial;
                        u.Cosmos = u.cInicial;
                        u.amorAZahori = u.amorZaho0;
                        PeleaCotraBronce(C1, u);

                    }
                }
            }
                

        }
        public void Terminar()
        {
            Console.WriteLine("\n\n\n\nResumen");
            for (int i = 0; i < 5; i++)
            {
                if (cBronces[i].Vida <= 0)
                {
                    cBronces[i].Vida = 0;
                    Console.WriteLine(cBronces[i].Nombre + " Vida : MUERTO    0/" + cBronces[i].Vida0);
                }
                else
                {

                    Console.WriteLine(cBronces[i].Nombre + " Vida : " + cBronces[i].Vida + "/" + cBronces[i].Vida0);
                }
            }


            for (int i = 0; i < 12; i++)
            {
                if (cOros[i].Vida <= 0)
                {
                    cOros[i].Vida = 0;
                    Console.WriteLine(cOros[i].Nombre + " Vida : MUERTO    0/" + cOros[i].Vida0);
                }
                else
                {
                    Console.WriteLine(cOros[i].Nombre + " Vida : " + cOros[i].Vida + "/" + cOros[i].Vida0);
                }
            }
           
        }

        public void VerQuienGana()
        {
            int u = 0;
            for (int i = 0; i < 12; i++)
            {
                if (cOros[i].Vida > 0)
                {
                    u++;
                }
            }
            if (Otro()!=null && (cOros[11].Vida==0 || cOros[11].turnosNoActuados>1))
            {
                Console.WriteLine("\n\n\n\nHAN GANADO LOS CABALLEROS DE BRONCE Y LA DONCELLA MILENARIA, ZAHORI GUIDO, HA SOBREVIVIDO!");
            }
            else if (u > 0 && Otro() == null)
            {
                Console.WriteLine("\n\n\n\nHAN GANADO LOS CABALLEROS DE ORO Y LA DONCELLA MILENARIA, ZAHORI GUIDO, HA MUERTO!");
            }
        }

        public bool puedenPelear(Caballero C1,Caballero C2){
            if (C1 == null || C2 == null)
            {
                return false;
            }
            if(C1.Vida>0 && C2.Vida>0 && Otro()!=null){
                return true;
            }else{
                return false;
            }

        }

        public void Pelea(Caballero C1, Caballero C2)
        {
            if (C1.Velocidad > C2.Velocidad)
            {
                    if (puedenPelear(C1, C2))
                    {
                    C1.Ataque(C2);

                    }
                int quienAtaca = r.Next(0,15);
                    if (quienAtaca<4 && puedenPelear(C1, C2))
                    {
                        C1.Ataque(C2);

                    }
                    else if (puedenPelear(C1, C2))
                    {
                        C2.Ataque(C1);

                    }
                
            }
            else
            {
                if (puedenPelear(C1, C2))
                {
                    C2.Ataque(C1);

                }
                Random ri = new Random();
                int quienAtaca = ri.Next(0, 15);
                if (quienAtaca < 4 && puedenPelear(C1, C2))
                {
                    C2.Ataque(C1);

                }
                else if (puedenPelear(C1, C2))
                {
                    C1.Ataque(C2);

                }

                
            }
        }

        public CaPlata GenerarCaballeroPlata()
        {
            Random ru = new Random();
            int pro=ru.Next(1, 101);
            CaPlata ret = new CaPlata("CaPlata");
            if (pro < 26)
            {
                return ret;
            }
            else
            {
                return null;
            }

        }

    }
}
