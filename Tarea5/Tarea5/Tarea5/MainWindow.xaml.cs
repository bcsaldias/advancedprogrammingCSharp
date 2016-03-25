using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using BackEnd;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea5
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Program p;
        Scroll win;
        public static event Action cerrarTodo;
        StackPanel ad;

        Thread t1;
        public MainWindow()
        {
            cerrarTodo += new Action(this.Close);
            p = new Program();
            InitializeComponent();
            this.Title = p.nombre;
            

            for (int i = 0; i < p.ancho; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < p.alto; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }

            ponerEdificios();
            ponerSemaforos();
            win = new Scroll();
            win.Show();
            ad = new StackPanel();
            win.scrollViewer1.Content = ad;
            t1 = new Thread(new ParameterizedThreadStart(verAccidentes));
            t1.Start(this);
            a = new object();
            //VehiculoCivil veic = new VehiculoCivil(p.vehiculosCiudad.ElementAt(0).posX, p.vehiculosCiudad.ElementAt(0).posY, p.vehiculosCiudad.ElementAt(0));
            //Grid.SetColumn(veic, p.vehiculosCiudad.ElementAt(0).posX);
            //Grid.SetRow(veic, p.vehiculosCiudad.ElementAt(0).posY);
            //grid.Children.Add(veic);
        }
        object a;
        private void verAccidentes(object o)
            {
                lock (a)
                {
                    while (true)
                    {
                        Thread.Sleep(1000);
                        if (Program.cambiarLuz.Count > 0)
                        {
                            SemaforoBackEnd sem = Program.cambiarLuz.ElementAt(0);
                            backedConFrontedSemaforo[sem.celdSemaforo[0]].cambiarColor(this);
                            backedConFrontedSemaforo[sem.celdSemaforo[1]].cambiarColor(this);
                            backedConFrontedSemaforo[sem.celdSemaforo[2]].cambiarColor(this);
                            backedConFrontedSemaforo[sem.celdSemaforo[3]].cambiarColor(this);
                            Program.cambiarLuz.ElementAt(0).time = Program.cambiarLuz.ElementAt(0).original;
                            Program.cambiarLuz.Remove(Program.cambiarLuz.ElementAt(0));
                        }
                        if (Program.sacarEmergencia.Count > 0)
                        {
                            Celdas celda = Program.sacarEmergencia.ElementAt(0).lugar;
                            celdasCell[celda].sacarImagen(this);
                            string al = "Asalto posX = " + celda.posX + " posY = " + celda.posY + " ESCAPÓ";
                            agregarAMenu(al);
                            Program.sacarEmergencia.Remove(Program.sacarEmergencia.ElementAt(0));
                        }
                        if (p.listaDeAccidentes.Count > 0)
                        {
                            Celdas celda = p.listaDeAccidentes.ElementAt(0).lugar;
                            celdasCell[celda].verAccidente(this);
                            string al = "Accidente posX = " + celda.posX + " posY = " + celda.posY;
                            agregarAMenu(al);

                            p.listaDeAccidentes.Remove(p.listaDeAccidentes.ElementAt(0));

                        }else if (p.listaDeAsaltos.Count>0){
                            Celdas celda = p.listaDeAsaltos.ElementAt(0).lugar;
                            celdasCell[celda].verAsalto(this);
                            celdasCell[celda].timeEscape = p.listaDeAsaltos.ElementAt(0).numero;
                            string al = "Asalto posX = " + celda.posX + " posY = " + celda.posY + " t escape " + celdasCell[celda].timeEscape;
                            agregarAMenu(al);
                            p.listaDeAsaltos.Remove(p.listaDeAsaltos.ElementAt(0));
                        }
                        else if (p.listaDeEnfermedades.Count > 0)
                        {
                            Celdas celda = p.listaDeEnfermedades.ElementAt(0).lugar;
                            celdasCell[celda].verEnfermedad(this);
                            string al = "Enfermedad posX = " + celda.posX + " posY = " + celda.posY;
                            agregarAMenu(al);
                            p.listaDeEnfermedades.Remove(p.listaDeEnfermedades.ElementAt(0));
                        }
                        else if (p.listaDeIncendios.Count > 0)
                        {
                            Celdas celda = p.listaDeIncendios.ElementAt(0).lugar;
                            celdasCell[celda].verIncendio(this);
                            string al = "Incendio posX = " + celda.posX + " posY = " + celda.posY;
                            agregarAMenu(al);
                            p.listaDeIncendios.Remove(p.listaDeIncendios.ElementAt(0));
                        }
                    }
                }
            }
        Dictionary<Celdas, Cell> celdasCell;
        Dictionary<Celdas, Semaforo> backedConFrontedSemaforo;
        private void ponerSemaforos(){
            Semaforo a=null;
            backedConFrontedSemaforo = new Dictionary<Celdas,Semaforo>();
            for (int i = 0; i < p.Semaforos.Count(); i++)
            {
                
                for (int j = 0; j < p.Semaforos.ElementAt(i).celdSemaforo.Length; j++)
                {
                    int posX = p.Semaforos.ElementAt(i).celdSemaforo.ElementAt(j).posX;
                    int posY = p.Semaforos.ElementAt(i).celdSemaforo.ElementAt(j).posY;
                    Material mat = p.Semaforos.ElementAt(i).celdSemaforo.ElementAt(j).material;
                    a = new Semaforo(posX, posY, p.Semaforos.ElementAt(i));
                    Grid.SetColumn(a, posX);
                    Grid.SetRow(a, posY);
                    grid.Children.Add(a);
                    backedConFrontedSemaforo.Add(p.Semaforos.ElementAt(i).celdSemaforo[j], a);
                }
                
            }

        }
        private void ponerEdificios()
        {   
            celdasCell = new Dictionary<Celdas,Cell>();
            for (int i = 0; i < p.Edificios.Count(); i++)
			{
                for (int j = 0; j < p.Edificios.ElementAt(i).celdasEdificio.Length; j++)
                {
                    int posX = p.Edificios.ElementAt(i).celdasEdificio.ElementAt(j).posX;
                    int posY = p.Edificios.ElementAt(i).celdasEdificio.ElementAt(j).posY;
                    Material mat = p.Edificios.ElementAt(i).celdasEdificio.ElementAt(j).material;
                    Cell a = new Cell(posX, posY, mat, p.Edificios.ElementAt(i).celdasEdificio.ElementAt(j));
                    Grid.SetColumn(a, posX);
                    Grid.SetRow(a, posY);
                    celdasCell.Add(p.Edificios.ElementAt(i).celdasEdificio.ElementAt(j), a);
                    grid.Children.Add(a);
                    a.ContextMenu = new ContextMenu();
                    MenuItem nombreEdifici = new MenuItem();
                    nombreEdifici.Header = "_Edificio " + a.logica.nombreEdificio;
                    a.ContextMenu.Items.Add(nombreEdifici);

                    if(a.logica.nombreEdificio == "Hospital"){
                        MenuItem numeroDePacientes = new MenuItem();
                        numeroDePacientes.Header = "_N° Pacientes " + 4;
                        a.ContextMenu.Items.Add(numeroDePacientes);
                    }
                    if (a.logica.nombreEdificio == "Comisaría")
                    {
                        MenuItem numeroDePacientes = new MenuItem();
                        numeroDePacientes.Header = "_N° Retén Móvil " + 4;
                        a.ContextMenu.Items.Add(numeroDePacientes);
                    }
                    if (a.logica.nombreEdificio == "Bomberos")
                    {
                        MenuItem numeroDePacientes = new MenuItem();
                        numeroDePacientes.Header = "_N° Camiones Disponibles " + 4;
                        a.ContextMenu.Items.Add(numeroDePacientes);
                    }
                    MenuItem material = new MenuItem();
                    material.Header = "_Material " + a.logica.material.nombreMaterial;
                    a.ContextMenu.Items.Add(material);

                    MenuItem inflamabilidad = new MenuItem();
                    inflamabilidad.Header = "_Inflamabilidad "+ a.logica.material.inflamable;
                    a.ContextMenu.Items.Add(inflamabilidad);
                    MenuItem enfermedad = new MenuItem();
                    enfermedad.Header = "_Enfermedad " + a.logica.material.sick;
                    a.ContextMenu.Items.Add(enfermedad);
                    MenuItem accidente = new MenuItem();
                    accidente.Header = "_Accidente " + p.PROBAaccidente;
                    a.ContextMenu.Items.Add(accidente);
                    MenuItem asalto = new MenuItem();
                    asalto.Header = "_Asalto " + p.PROBAasalto;
                    a.ContextMenu.Items.Add(asalto);


                   
                }
			}
            
        }


        public void agregarAMenu(object ob)
        {
            this.Dispatcher.BeginInvoke(new Action<object>(agregarAMenuDispatcher), ob);
        }
        private void agregarAMenuDispatcher(object recivido)
        {
            TextBlock b = new TextBlock();
            b.Text = (string)recivido;
            lock (this)
            {
                try
                {
                    ad.Children.Add(b);
                }
                catch { }
            }
        }

        private void ventana_Closed(object sender, EventArgs e)
        {
            cerrarTodo();
        }



    }
}
