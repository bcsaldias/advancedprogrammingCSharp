using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.Text;


namespace BackEnd
{
    public class Program
    {
        //public List<Emergencia> listaDeEmergencias;
        #region
        public Celdas[,] mapaDeCeldas;
        public List<Edificio> Edificios;
        public List<SemaforoBackEnd> Semaforos;
        public List<Material> Materiales;
        public List<Accidente> listaDeAccidentes;
        public List<Enfermedad> listaDeEnfermedades;
        public List<Asalto> listaDeAsaltos;
        public List<Incendio> listaDeIncendios;
        public static List<Emergencia> sacarEmergencia;
        public static List<SemaforoBackEnd> cambiarLuz;
        public Thread Bomberos;
        public Thread Policia;
        public Thread Hospital;
        int nu;
        public static MatrizCalles MCalles;
        int[,] matriz;
        public string nombre;
        public int ancho;
        public int alto;
        public double PROBAaccidente;
        public double PROBAenfermedad;
        public double PROBAasalto;
        public double PROBAincendio;
        public XmlNodeList building;
        public XmlNodeList material;
        public XmlNodeList streetlight;
        XmlNodeList at;
        XmlAttributeCollection atA;
        double w;
        double k;
        string mat;
        string nombreEdificio;
        int time;
        Thread ciudad;
        #endregion // variables
        static void Main(string[] args)
        {
        }
        public Program()
        {   
            listaDeAccidentes = new List<Accidente>();
            listaDeAsaltos = new List<Asalto>();
            listaDeEnfermedades = new List<Enfermedad>();
            listaDeIncendios = new List<Incendio>();
            sacarEmergencia = new List<Emergencia>();
            cambiarLuz = new List<SemaforoBackEnd>();

            eventEnfermedad += ocurrioEnfermedad;
            eventIncendio += ocurrioIncendio;
            Hospital = new Thread(new ParameterizedThreadStart(hospitalActuar));
            Policia = new Thread(new ParameterizedThreadStart(policiaActuar));
            ciudad = new Thread(new ParameterizedThreadStart(Simular));
            ciudad.Start();
        }
        //invento de auto
        //public List<VehiculoBackEnd> vehiculosCiudad = new List<VehiculoBackEnd>();
        private void Simular(object o)
        {
            ArmarCiudad();
            //VehiculoBackEnd nuev = new VehiculoBackEnd(16, 5);
            //vehiculosCiudad.Add(nuev);
            while (true)
            {
                Thread.Sleep(1000);
                AparicionDesastre();
                if (restarSemaforos != null)
                {
                    restarSemaforos();
                }
                if (restarNumero != null)
                {
                    restarNumero();
                }
                if (listaDeAsaltos.Count == 3)
                {
                    try
                    {
                        Policia.Start();
                    }
                    catch { }
                }
            } 
            
        }

        private void policiaActuar(object o)
        {
            //falta  todo lo que hace la policía
            Policia.Abort();
        }
        private void hospitalActuar(object o)
        {
            //falta  todo lo que hace el hospital
            Hospital.Abort();
        }

        public event Action restarNumero;
        public event Action restarSemaforos;

        private void ocurrioEnfermedad(Celdas celda){
            Random r = new Random();
            Random queEdificio = new Random();
            int qEdif = r.Next(0, Edificios.Count);
            int posX = celda.posX;
            int posY = celda.posY;

            if (posX-1> 0 && posY -1> 0 && posX + 1 < ancho && posY+1 < alto)
            {

                if (mapaDeCeldas[posX - 1, posY - 1] != null && mapaDeCeldas[posX - 1, posY - 1].hayEmergencia == false && mapaDeCeldas[posX - 1, posY - 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX - 1, posY - 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX - 1, posY - 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX - 1, posY - 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX - 1, posY - 1].nombreEdificio != "Hospital")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX - 1, posY - 1]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
                if (mapaDeCeldas[posX - 1, posY] != null && mapaDeCeldas[posX - 1, posY].hayEmergencia == false && mapaDeCeldas[posX - 1, posY].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX - 1, posY].material.nombreMaterial != "Special" && mapaDeCeldas[posX - 1, posY].nombreEdificio != "Comisaría" && mapaDeCeldas[posX - 1, posY].nombreEdificio != "Bombreros" && mapaDeCeldas[posX - 1, posY].nombreEdificio!="Hospital")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX - 1, posY]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
                if (mapaDeCeldas[posX - 1, posY + 1] != null && mapaDeCeldas[posX - 1, posY + 1].hayEmergencia == false && mapaDeCeldas[posX - 1, posY + 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX - 1, posY + 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX - 1, posY + 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX - 1, posY + 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX - 1, posY + 1].nombreEdificio!="Hospital")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX - 1, posY + 1]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);

                }
                if (mapaDeCeldas[posX, posY - 1] != null && mapaDeCeldas[posX, posY - 1].hayEmergencia == false && mapaDeCeldas[posX, posY - 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX, posY - 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX, posY - 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX, posY - 1].nombreEdificio != "Hospital" && mapaDeCeldas[posX, posY - 1].nombreEdificio!="Comisaría")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX, posY - 1]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
                if (mapaDeCeldas[posX, posY + 1] != null && mapaDeCeldas[posX, posY + 1].hayEmergencia == false && mapaDeCeldas[posX, posY + 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX, posY + 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX, posY + 1].nombreEdificio != "Hospital" && mapaDeCeldas[posX, posY + 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX, posY + 1].nombreEdificio!="Bomberos")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX, posY + 1]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
                if (mapaDeCeldas[posX + 1, posY - 1] != null && mapaDeCeldas[posX + 1, posY - 1].hayEmergencia == false && mapaDeCeldas[posX + 1, posY - 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX + 1, posY - 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX + 1, posY - 1].nombreEdificio != "Hospital" && mapaDeCeldas[posX + 1, posY - 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX + 1, posY - 1].nombreEdificio!="Comisaría")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX + 1, posY - 1]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
                if (mapaDeCeldas[posX + 1, posY] != null && mapaDeCeldas[posX + 1, posY].hayEmergencia == false && mapaDeCeldas[posX + 1, posY].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX + 1, posY].material.nombreMaterial != "Special" && mapaDeCeldas[posX + 1, posY].nombreEdificio != "Hospital" && mapaDeCeldas[posX + 1, posY].nombreEdificio != "Comisaría" && mapaDeCeldas[posX + 1, posY].nombreEdificio!="Bomberos")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX + 1, posY]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
                if (mapaDeCeldas[posX + 1, posY + 1] != null && mapaDeCeldas[posX + 1, posY + 1].hayEmergencia == false && mapaDeCeldas[posX + 1, posY + 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX + 1, posY + 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX + 1, posY + 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX + 1, posY + 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX + 1, posY + 1].nombreEdificio!="Hospital")
                {
                    Enfermedad enfermedad = new Enfermedad((mapaDeCeldas[posX + 1, posY + 1]));
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                }
            }
        }

        private void ocurrioIncendio(Celdas celda)
        {
            Random r = new Random();
            Random queEdificio = new Random();
            int qEdif = r.Next(0, Edificios.Count);
            int posX = celda.posX;
            int posY = celda.posY;

            if (posX - 1 > 0 && posY - 1 > 0 && posX + 1 < ancho && posY + 1 < alto)
            {

                if (mapaDeCeldas[posX - 1, posY - 1] != null && mapaDeCeldas[posX - 1, posY - 1].hayEmergencia == false && mapaDeCeldas[posX - 1, posY - 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX - 1, posY - 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX - 1, posY - 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX - 1, posY - 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX - 1, posY - 1].nombreEdificio != "Hospital")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX - 1, posY - 1]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
                if (mapaDeCeldas[posX - 1, posY] != null && mapaDeCeldas[posX - 1, posY].hayEmergencia == false && mapaDeCeldas[posX - 1, posY].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX - 1, posY].material.nombreMaterial != "Special" && mapaDeCeldas[posX - 1, posY].nombreEdificio != "Comisaría" && mapaDeCeldas[posX - 1, posY].nombreEdificio != "Bombreros" && mapaDeCeldas[posX - 1, posY].nombreEdificio != "Hospital")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX - 1, posY]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
                if (mapaDeCeldas[posX - 1, posY + 1] != null && mapaDeCeldas[posX - 1, posY + 1].hayEmergencia == false && mapaDeCeldas[posX - 1, posY + 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX - 1, posY + 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX - 1, posY + 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX - 1, posY + 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX - 1, posY + 1].nombreEdificio != "Hospital")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX - 1, posY+ 1]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);

                }
                if (mapaDeCeldas[posX, posY - 1] != null && mapaDeCeldas[posX, posY - 1].hayEmergencia == false && mapaDeCeldas[posX, posY - 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX, posY - 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX, posY - 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX, posY - 1].nombreEdificio != "Hospital" && mapaDeCeldas[posX, posY - 1].nombreEdificio != "Comisaría")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX, posY - 1]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
                if (mapaDeCeldas[posX, posY + 1] != null && mapaDeCeldas[posX, posY + 1].hayEmergencia == false && mapaDeCeldas[posX, posY + 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX, posY + 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX, posY + 1].nombreEdificio != "Hospital" && mapaDeCeldas[posX, posY + 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX, posY + 1].nombreEdificio != "Bomberos")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX, posY + 1]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
                if (mapaDeCeldas[posX + 1, posY - 1] != null && mapaDeCeldas[posX + 1, posY - 1].hayEmergencia == false && mapaDeCeldas[posX + 1, posY - 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX + 1, posY - 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX + 1, posY - 1].nombreEdificio != "Hospital" && mapaDeCeldas[posX + 1, posY - 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX + 1, posY - 1].nombreEdificio != "Comisaría")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX + 1, posY - 1]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
                if (mapaDeCeldas[posX + 1, posY] != null && mapaDeCeldas[posX + 1, posY].hayEmergencia == false && mapaDeCeldas[posX + 1, posY].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX + 1, posY].material.nombreMaterial != "Special" && mapaDeCeldas[posX + 1, posY].nombreEdificio != "Hospital" && mapaDeCeldas[posX + 1, posY].nombreEdificio != "Comisaría" && mapaDeCeldas[posX + 1, posY].nombreEdificio != "Bomberos")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX + 1, posY]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
                if (mapaDeCeldas[posX + 1, posY + 1] != null && mapaDeCeldas[posX + 1, posY + 1].hayEmergencia == false && mapaDeCeldas[posX + 1, posY + 1].material.sick >= r.Next(1, 101) && mapaDeCeldas[posX + 1, posY + 1].material.nombreMaterial != "Special" && mapaDeCeldas[posX + 1, posY + 1].nombreEdificio != "Bomberos" && mapaDeCeldas[posX + 1, posY + 1].nombreEdificio != "Comisaría" && mapaDeCeldas[posX + 1, posY + 1].nombreEdificio != "Hospital")
                {
                    Incendio incendio = new Incendio((mapaDeCeldas[posX + 1, posY + 1]));
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventEnfermedad(incendio.lugar);
                }
            }
        }

        public event Action<Celdas> eventEnfermedad;
        public event Action<Celdas> eventIncendio;

        private void AparicionDesastre()
        {
            Random r = new Random();
            Random queEdificio = new Random();
            int qEdif = r.Next(0, Edificios.Count);
            if(r.Next(1,101)<=PROBAaccidente*100){
                Accidente accidente = new Accidente(Edificios.ElementAt(qEdif).celdasEdificio.ElementAt(queEdificio.Next(0, Edificios.ElementAt(qEdif).celdasEdificio.Length)));
                if (accidente.lugar.hayEmergencia == false && accidente.lugar.nombreEdificio != "Hospital" && accidente.lugar.nombreEdificio != "Bomberos" && accidente.lugar.nombreEdificio != "Comisaría")
                {
                    listaDeAccidentes.Add(accidente);
                    accidente.lugar.hayEmergencia = true;
                    try
                    {
                        Hospital.Start();
                    }
                    catch { }
                }
            }
            if (r.Next(1, 101) <= PROBAenfermedad * 100)
            {
                Enfermedad enfermedad = new Enfermedad(Edificios.ElementAt(qEdif).celdasEdificio.ElementAt(r.Next(0, Edificios.ElementAt(qEdif).celdasEdificio.Length)));
                if (enfermedad.lugar.hayEmergencia == false && enfermedad.lugar.nombreEdificio != "Hospital" && enfermedad.lugar.nombreEdificio != "Bomberos" && enfermedad.lugar.nombreEdificio != "Comisaría")
                {
                    listaDeEnfermedades.Add(enfermedad);
                    enfermedad.lugar.hayEmergencia = true;
                    eventEnfermedad(enfermedad.lugar);
                    try
                    {
                        Hospital.Start();
                    }
                    catch { }
                }
            }
            if (r.Next(1, 101) <= PROBAasalto * 100)
            {
                Asalto asalto = new Asalto(Edificios.ElementAt(qEdif).celdasEdificio.ElementAt(r.Next(0, Edificios.ElementAt(qEdif).celdasEdificio.Length)));
                if (asalto.lugar.hayEmergencia == false && asalto.lugar.nombreEdificio != "Hospital" && asalto.lugar.nombreEdificio != "Bomberos" && asalto.lugar.nombreEdificio != "Comisaría")
                {
                    listaDeAsaltos.Add(asalto);
                    asalto.lugar.hayEmergencia = true;
                    restarNumero += asalto.restar;
                    try
                    {
                        Policia.Start();
                    }
                    catch { }
                }
            }
            if (r.Next(1, 101) <= PROBAincendio * 100)
            {
                Incendio incendio = new Incendio(Edificios.ElementAt(qEdif).celdasEdificio.ElementAt(r.Next(0, Edificios.ElementAt(qEdif).celdasEdificio.Length)));
                if (incendio.lugar.hayEmergencia == false && incendio.lugar.nombreEdificio != "Hospital" && incendio.lugar.nombreEdificio != "Bomberos" && incendio.lugar.nombreEdificio != "Comisaría")
                {
                    listaDeIncendios.Add(incendio);
                    incendio.lugar.hayEmergencia = true;
                    eventIncendio(incendio.lugar);
                }
            }

        }
        private void ArmarCiudad()
        {
            LeerArchivo(@".\..\..\Juanfiladelfia.Xml");

        }
        private void LeerArchivo(string path)
        {
            XmlDocument a = new XmlDocument();
            a.Load(path);
            XmlNode raiz = a.DocumentElement;
            XmlAttributeCollection atributos = raiz.Attributes;
            XmlNode name = atributos.Item(0);
            XmlNode width = atributos.Item(1);
            XmlNode height = atributos.Item(2);
            XmlNode accident = atributos.Item(3);
            XmlNode sicknnes = atributos.Item(4);
            XmlNode crime = atributos.Item(5);
            XmlNode fire = atributos.Item(6);
            nombre = name.Value;
            ancho = Convert.ToInt32(width.Value);
            alto = Convert.ToInt32(height.Value);
            PROBAaccidente = Convert.ToDouble(accident.Value.Replace(".", ","));
            PROBAenfermedad = Convert.ToDouble(sicknnes.Value.Replace(".", ","));
            PROBAasalto = Convert.ToDouble(crime.Value.Replace(".", ","));
            PROBAincendio = Convert.ToDouble(fire.Value.Replace(".", ","));
            building = a.GetElementsByTagName("building");
            material = a.GetElementsByTagName("material");
            streetlight = a.GetElementsByTagName("streetlight");
            Materiales = new List<Material>();
            Semaforos = new List<SemaforoBackEnd>();
            Edificios = new List<Edificio>();
            mapaDeCeldas = new Celdas[ancho, alto];

            matriz = new int[ancho,alto];
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < alto; j++)
                {
                    matriz[i, j] = -5;
                }
            }
            for (int j = 0; j < material.Count; j++)
            {
                    Material mater;
                    atA = material.Item(j).Attributes;
                    XmlNode W = atA.Item(1);
                    XmlNode K = atA.Item(2);
                    w = Convert.ToDouble(W.Value.Replace(".", ",")); //sick
                    k = Convert.ToDouble(K.Value.Replace(".", ",")); //inflamability
                    mat = atA.Item(0).Value;
                    mater = new Material(mat, w, k);
                    Materiales.Add(mater);
            }
            
            for (int j = 0; j < streetlight.Count; j++)
            {
                SemaforoBackEnd semaforo;
                Celdas[] celdas = new Celdas[streetlight.Item(j).ChildNodes.Count];
                at = streetlight.Item(j).ChildNodes;
                time = Convert.ToInt32(streetlight.Item(j).Attributes.Item(0).Value);
                for (int i = 0; i < streetlight.Item(j).ChildNodes.Count; i++)
                {
                    atA = at.Item(i).Attributes;
                    w = Convert.ToInt32(atA.Item(0).Value);
                    k = Convert.ToInt32(atA.Item(1).Value);
                    mat = "semaforo";
                    celdas[i] = new Celdas((int)w, (int)k, establecerMaterial(mat), "semaforo");
                    matriz[(int)w, (int)k] = -2; 
                }
                semaforo = new SemaforoBackEnd(celdas, time);
                restarSemaforos += semaforo.restar;
                Semaforos.Add(semaforo);
            }
            
            for (int j = 0; j < building.Count; j++)
            {
                Edificio edificio;
                at = building.Item(j).ChildNodes;
                nombreEdificio = building.Item(j).Attributes.Item(0).Value;
                Celdas[] celdas = new Celdas[building.Item(j).ChildNodes.Count];
                for (int i = 0; i < building.Item(j).ChildNodes.Count; i++)
                {
                    atA = at.Item(i).Attributes;
                    w = Convert.ToInt32(atA.Item(0).Value);
                    k = Convert.ToInt32(atA.Item(1).Value);
                    mat = atA.Item(2).Value;
                    celdas[i] = new Celdas((int)w, (int)k, establecerMaterial(mat),nombreEdificio);
                    matriz[(int)w, (int)k] = 0;
                    mapaDeCeldas[(int)w, (int)k] = celdas[i];
                }
                edificio = new Edificio(celdas,building.Item(j).ChildNodes.Item(0).Value);
                Edificios.Add(edificio);
            }

            MCalles = new MatrizCalles(matriz);
        }
        private Material establecerMaterial(string mat)
        {

            for (int i = 0; i < Materiales.Count; i++)
            {
                if (mat == Materiales.ElementAt(i).nombreMaterial)
                {
                    return Materiales.ElementAt(i);
                }
            }
            return null;
        }
        ManualResetEvent[] asaltEnfila = new ManualResetEvent[3];
        List<int> asaltantes;




    }
}
