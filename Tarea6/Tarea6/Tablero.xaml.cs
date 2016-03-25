using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Threading;
using BackEnd;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para Tablero.xaml
    /// </summary>
    public partial class Tablero : UserControl
    {
        public Program programa;
        Server servidor;
        Jugador jugador;

        Cell[,] celdasTotales;

        public static Dictionary<CeldasBarcoBackend, Cell> Backend__Cell;
        public static Dictionary<Cell, CeldasBarcoBackend> Cell__Backend;

        static public Dictionary<int[],Cell> intCell;

        private void ganador(int d)
        {
            MessageBox.Show("El soberano de iRone Throne es el Jugador " + d);
        }

        public Tablero(Server servidor, Jugador jugador)
        {
            Backend__Cell = new Dictionary<CeldasBarcoBackend, Cell>();
            Cell__Backend = new Dictionary<Cell, CeldasBarcoBackend>();

            intCell = new Dictionary<int[],Cell>();

            celdasTotales = new Cell[40,40];

            this.servidor = servidor;
            this.jugador = jugador;
            if (servidor != null)
            {
                programa = servidor.p;
            }
            InitializeComponent();

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Cell a = new Cell(i, j, null, null, jugador, servidor);
                    celdasTotales[i, j] = a;
                    int[] enter = {1000*i,1000*j};
                    intCell.Add(enter, a);
                    Grid.SetColumn(a, i);
                    Grid.SetRow(a, j);
                    grid.Children.Add(a);
                }
            }

            #region
            for (int i = 0; i < 40; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int j = 0; j < 40; j++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            #endregion
            
            if (servidor != null)
            {
                servidor.p.hayGanador += ganador;
                
                Tytanic t = (Tytanic)programa.una[0];
                MerrilMarineForce m = (MerrilMarineForce)programa.una[1];
                Trololo tro = (Trololo)programa.una[2];
                PernaNegra per = (PernaNegra)programa.una[3];
                HolandesVolador h = (HolandesVolador)programa.una[4];

                Barco[] arrB = { t, m, tro, per, h };

                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < arrB[j].celdasDelBarco.Length; i++)
                    {
                        CeldasBarcoBackend logica = arrB[j].celdasDelBarco[i];
                        Cell a = new Cell(arrB[j].celdasDelBarco[i].posX, arrB[j].celdasDelBarco[i].posY, arrB[j],logica, null, servidor);
                        Grid.SetColumn(a, arrB[j].celdasDelBarco[i].posX);
                        Grid.SetRow(a, arrB[j].celdasDelBarco[i].posY);
                        Backend__Cell.Add(arrB[j].celdasDelBarco[i], a);
                        Cell__Backend.Add(a, arrB[j].celdasDelBarco[i]);
                        int[] o = { arrB[j].celdasDelBarco[i].posX, arrB[j].celdasDelBarco[i].posY };
                        intCell.Add(o, a);
                        grid.Children.Add(a);
                    }
                }
                #region
                for (int r = 1; r < servidor.p.todosBarcos.Length; r++)
                {

                    Barco[] arr = servidor.p.todosBarcos[r];
                    for (int j = 0; j < 5; j++)
                    {
                        for (int i = 0; i < arr[j].celdasDelBarco.Length; i++)
                        {
                            Cell a = new Cell(arr[j].celdasDelBarco[i].posX, arr[j].celdasDelBarco[i].posY, arr[j], arr[j].celdasDelBarco[i], null, null);
                            Backend__Cell.Add(arr[j].celdasDelBarco[i], a);
                            Cell__Backend.Add(a, arr[j].celdasDelBarco[i]);
                            int[] o = { arrB[j].celdasDelBarco[i].posX, arrB[j].celdasDelBarco[i].posY };
                            intCell.Add(o, a);
                        }
                    }

                }

                #endregion
            }

            if (jugador != null)
            {
                jugador.hayGanador += ganador;
                Barco[] arrB = jugador.misBarcos;
                for (int j = 0; j < 5; j++)
                {
                    for (int i = 0; i < arrB[j].celdasDelBarco.Length; i++)
                    {
                        Cell a = new Cell(arrB[j].celdasDelBarco[i].posX, arrB[j].celdasDelBarco[i].posY, arrB[j], arrB[j].celdasDelBarco[i],jugador,null);
                        Grid.SetColumn(a, arrB[j].celdasDelBarco[i].posX);
                        Grid.SetRow(a, arrB[j].celdasDelBarco[i].posY);
                        Backend__Cell.Add(arrB[j].celdasDelBarco[i], a);
                        celdasTotales[arrB[j].celdasDelBarco[i].posX, arrB[j].celdasDelBarco[i].posY] = a;
                        int[] ar = { arrB[j].celdasDelBarco[i].posX, arrB[j].celdasDelBarco[i].posY };
                        intCell.Add(ar, a);
                        grid.Children.Add(a);
                    }
                }


                Thread esperarJugada = new Thread(new ParameterizedThreadStart(revisarCambio));
                esperarJugada.Start(this);
            }



        }
        private void revisarCambio(object o)
        {
            while (true)
            {
                if (jugador.jugadaRecivida.Count>0)
                {
                    int[] a = {jugador.jugadaRecivida.ElementAt(0).posX,jugador.jugadaRecivida.ElementAt(0).posY};
                    celdasTotales[jugador.jugadaRecivida.ElementAt(0).posX, jugador.jugadaRecivida.ElementAt(0).posY].revisarCambio(jugador.jugadaRecivida.ElementAt(0));
                    jugador.jugadaRecivida.Remove(jugador.jugadaRecivida.ElementAt(0));
                }
                if (jugador.barcoRecivido.Count > 0)
                {
                    Barco b = jugador.barcoRecivido.ElementAt(0);
                    pintarBarco(b);
                    jugador.barcoRecivido.Remove(jugador.barcoRecivido.ElementAt(0));
                }

            }
        }
        public void pintarBarco(Barco b) {
            if (b != null)
            {
                //lock (b)
                //{
                    for (int i = 0; i < b.celdasDelBarco.Length; i++)
                    {
                        celdasTotales[b.celdasDelBarco[i].posX, b.celdasDelBarco[i].posY].cambiarlr(b.celdasDelBarco[i].atacado);
                    }
                //}
            }
            //MessageBox.Show("hola debo pintarme"); //falta el servidor
        }

        public void Agrandar(int alto,int ancho)
        {
            this.Dispatcher.BeginInvoke(new Action<int,int>(AgrandarDispatcher),alto,ancho);
        }
        private void AgrandarDispatcher(int alto,int ancho)
        {
            this.Width =  alto-110;
            grid.Width = alto - 110;
            this.Height = alto-40;
            grid.Height = alto - 110;
            cannno.Width = alto - 110;
            cannno.Height = 70;
            cannno.Margin = new Thickness(0, alto - 109, 0, 0);
            Canvas.SetLeft(this, ancho/2-alto/2+21);   
            
        }

      
    }
}
