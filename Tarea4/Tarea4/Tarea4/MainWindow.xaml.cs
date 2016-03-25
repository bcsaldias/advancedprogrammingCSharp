using System;
using BackEnd;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string toPlot;
        public static Canvas ufu;
        UserControl nextClick;
        MenuItem delete;
        MenuItem execute;
        object ultimo = new object();
        int j=0;
        public MainWindow()
        {
            cerrarTodo += new Action(this.Close);
            InitializeComponent();
            ufu = uf;
        }

        private void Salir_Click(object sender , RoutedEventArgs e)
        {
            cerrarTodo();

        }
        public static event Action cerrarTodo;

        private void Custom_Click(object sender, RoutedEventArgs e)
        {
            //crear VentanaCustomBackEnd ventana = new VentanaCustomBackEnd(0,0);
            Custom c = new Custom();
            c.Show();
            cerrarTodo += new Action(c.Close);
            
            
        }

        private void Plotter_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Plotter();
            Plotter plo = (Plotter)nextClick;
            Eject += new Action<object, RoutedEventArgs>(plo.a);
        }
       
        private void Suma_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Suma();
            Suma sum = (Suma)nextClick;
            Eject += new Action<object, RoutedEventArgs>(sum.a);
        }

        private void Canvas_CLick(object sender, MouseButtonEventArgs mouse)
        {
            ju = mouse;
            if (nextClick is Linea)
            {
                nextClick = null;
            }else if (nextClick != null)
                {
                    Point posicion = mouse.GetPosition(this);
                  if(posicion.Y> 26){
                    Canvas.SetTop(nextClick, posicion.Y);
                    Canvas.SetLeft(nextClick, posicion.X);
                    uf.Children.Add(nextClick);
                    nextClick.ContextMenu = new ContextMenu();
                    MenuItem conectar = new MenuItem();
                    conectar.Header = "_Conectar";
                    nextClick.ContextMenu.Items.Add(conectar);
                    conectar.Click += hacerLinea;
                    MenuItem CancelarConexion = new MenuItem();
                    CancelarConexion.Header = "_Cancelar Conexión";
                    nextClick.ContextMenu.Items.Add(CancelarConexion);
                    CancelarConexion.Click += noHacerLinea;
                    delete = new MenuItem();
                    delete.Header = "_Borrar";
                    nextClick.ContextMenu.Items.Add(delete);
                    execute = new MenuItem();
                    execute.Header = "_Ejecutar";
                    nextClick.ContextMenu.Items.Add(execute);
                   
                    if (nextClick is Suma)
                    {
                        Suma res = (Suma)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Resta)
                    {
                        Resta res = (Resta)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Multiplicación)
                    {
                        Multiplicación res = (Multiplicación)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is División)
                    {
                        División res = (División)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Input)
                    {
                        Input res = (Input)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is OutputIntermedio)
                    {
                        OutputIntermedio res = (OutputIntermedio)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is OutputFinal)
                    {
                        OutputFinal res = (OutputFinal)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Factorial)
                    {
                        Factorial res = (Factorial)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Seno)
                    {
                        Seno res = (Seno)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Coseno)
                    {
                        Coseno res = (Coseno)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is ComparadorDistinto)
                    {
                        ComparadorDistinto res = (ComparadorDistinto)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is ComparadorIgual)
                    {
                        ComparadorIgual res = (ComparadorIgual)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }

                    else if (nextClick is ComparadorMayor)
                    {
                        ComparadorMayor res = (ComparadorMayor)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is ComparadorMayorIgual)
                    {
                        ComparadorMayorIgual res = (ComparadorMayorIgual)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is ComparadorMenor)
                    {
                        ComparadorMenor res = (ComparadorMenor)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;

                    }
                    else if (nextClick is ComparadorMenorIgual)
                    {
                        ComparadorMenorIgual res = (ComparadorMenorIgual)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Fibonacci)
                    {
                        Fibonacci res = (Fibonacci)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Separador)
                    {
                        Separador res = (Separador)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
                    else if (nextClick is Plotter)
                    {
                        Plotter res = (Plotter)nextClick;
                        res.a(sender, mouse);
                        execute.Click += res.a;
                        delete.Click += res.b;
                    }
















                  }
                    nextClick = null;
                }
        }

        #region
        private void Input_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Input();
        }

        private void Output_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Final_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new OutputFinal();
            OutputFinal res = (OutputFinal)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Intermedio_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new OutputIntermedio();
            OutputIntermedio res = (OutputIntermedio)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Separador_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Separador();
            Separador res = (Separador)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Aritméticas_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Multiplicación_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Multiplicación();
            Multiplicación mult = (Multiplicación)nextClick;
            Eject += new Action<object, RoutedEventArgs>(mult.a);
        }

        private void División_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new División();
            División div = (División)nextClick;
            Eject += new Action<object, RoutedEventArgs>(div.a);

        }

        private void Comparadores_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Funciones_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InicioIntervalo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FinIntervalo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Step_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Resta_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Resta();
            Resta res = (Resta)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);

        }

        private void igual_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new ComparadorIgual();
            ComparadorIgual res = (ComparadorIgual)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void menor_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new ComparadorMenor();
            ComparadorMenor res = (ComparadorMenor)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void mayor_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new ComparadorMayor();
            ComparadorMayor res = (ComparadorMayor)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void menorIgual_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new ComparadorMenorIgual();
            ComparadorMenorIgual res = (ComparadorMenorIgual)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void mayorIgual_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new ComparadorMayorIgual();
            ComparadorMayorIgual res = (ComparadorMayorIgual)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void distinto_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new ComparadorDistinto();
            ComparadorDistinto res = (ComparadorDistinto)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Seno_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Seno();
            Seno res = (Seno)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Coseno_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Coseno();
            Coseno res = (Coseno)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Factorial_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Factorial();
            Factorial res = (Factorial)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        private void Fibonacci_Click(object sender, RoutedEventArgs e)
        {
            nextClick = new Fibonacci();
            Fibonacci res = (Fibonacci)nextClick;
            Eject += new Action<object, RoutedEventArgs>(res.a);
        }

        
        private void Ejecutar_Click(object sender, RoutedEventArgs e)
        {
              Eject(sender, e);
        }

        #endregion// hola
        public event Action<object, RoutedEventArgs> Eject;

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            uf.Children.RemoveRange(1, uf.Children.Count);
        }

        MouseButtonEventArgs ju;

        private void noHacerLinea(object sender, RoutedEventArgs e)
        {
            lili = 0;
        }

        private void hacerLinea(object sender, RoutedEventArgs e)
        {
            nextClick = new Linea();
            uf_P(sender, ju, (Linea)nextClick);// mandar el canvas actual, los grid tienen hijo s ??
        }

        int lili = 0;
        Point positi = new Point();
        Point position = new Point();
        public static UserControl inicia;
        public static UserControl finaliza;
        private void uf_P(object sender, MouseButtonEventArgs e, Linea lin/*, Canvas a*/)
        {
            if (lili == 0)
            {
                positi = e.GetPosition(this);
                lili = 1;   
            }
            else
            {
                position = e.GetPosition(this);
                if (lin.CreateALine(positi, position, 1, uf))
                { 
                    u(sender, e);
                }
                lili = 0;  
            }
        }

        private void u(object sender, MouseButtonEventArgs e)
        {
            Point posicion = e.GetPosition(this);
            if (nextClick is Linea)
            {
                //MessageBox.Show("holi");
                Canvas.SetTop(nextClick, positi.Y);
                Canvas.SetLeft(nextClick, positi.X);
                nextClick.ContextMenu = new ContextMenu();
                MenuItem conectar = new MenuItem();
                delete = new MenuItem();
                delete.Header = "_Borrar";
                nextClick.ContextMenu.Items.Add(delete);
                uf.Children.Add(nextClick);
                Linea li = (Linea)nextClick;
                delete.Click += li.b;
            }
            nextClick = null;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            cerrarTodo();
        }

        private void seno_Click_1(object sender, RoutedEventArgs e)
        {
            toPlot = "seno";
        }

        private void coseno_Click_1(object sender, RoutedEventArgs e)
        {
            toPlot = "coseno";
        }

        private void factorial_Click_1(object sender, RoutedEventArgs e)
        {
            toPlot = "factorial";
        }

        private void fibonacci_Click_1(object sender, RoutedEventArgs e)
        {
            toPlot = "fibonacci";
        }


    }
}
