using System;
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
using BackEnd;
using System.Windows.Shapes;

namespace Tarea4
{
    /// <summary>
    /// Lógica de interacción para Plotter.xaml
    /// </summary>
    public partial class Plotter : UserControl
    {
        public PlotterBackEnd logica;
        Separador pprim;
        Separador pseg;
        Separador pter;
        OutputIntermedio paraPrimeroO;
        OutputIntermedio paraSegundoO;
        OutputIntermedio paraTerceroO;
        public Input paraPrimero;
        public Input paraSegundo;
        Input paraTercero;
        public Plotter()
        {
            InitializeComponent();
            logica = new PlotterBackEnd(MainWindow.toPlot);
        }

        public void a(object sender, RoutedEventArgs e)
        {
            if (paraPrimero != null)
            {
                prim.Text = paraPrimero.prim.Text;
            }
            if (paraSegundo != null)
            {
                seg.Text = paraSegundo.prim.Text;
            }
            if (paraTercero != null)
            {
                ter.Text = paraTercero.prim.Text;
            }
            if (paraPrimeroO != null)
            {
                prim.Text = paraPrimeroO.textBlock2.Text;
            }
            if (paraSegundoO != null)
            {
                seg.Text = paraSegundoO.textBlock2.Text;
            }
            if (paraTerceroO != null)
            {
                ter.Text = paraTerceroO.textBlock2.Text;
            }
            if (pprim != null)
            {
                prim.Text = pprim.textBlock1.Text;
            }
            if (pseg != null)
            {
                seg.Text = pseg.textBlock1.Text;
            }
            if (pter != null)
            {
                ter.Text = pter.textBlock1.Text;
            }
            if(Double.TryParse(this.prim.Text, out logica.inicio) && Double.TryParse(this.seg.Text, out logica.final) && Double.TryParse(this.ter.Text, out logica.step)){
                //if(logica.graficar()){
                    Gráfico g = new Gráfico(this);
                    //g.Show();
                
            }

        }
        public void b(object sender, RoutedEventArgs e)
        {
            MainWindow.ufu.Children.Remove(this);
        }

        private void prim_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.finaliza = this;
            if (MainWindow.inicia is Input)
            {
                Input ini = (Input)MainWindow.inicia;
                paraPrimero = ini;
            }
            else if (MainWindow.inicia is OutputIntermedio)
            {
                OutputIntermedio ini = (OutputIntermedio)MainWindow.inicia;
                paraPrimeroO = ini;
            }
            else if (MainWindow.inicia is Separador)
            {
                Separador ini = (Separador)MainWindow.inicia;
                pprim = ini;

            }
        }

        private void seg_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.finaliza = this;
            if (MainWindow.inicia is Input)
            {
                Input ini = (Input)MainWindow.inicia;
                paraTercero = ini;
            }
            else if (MainWindow.inicia is OutputIntermedio)
            {
                OutputIntermedio ini = (OutputIntermedio)MainWindow.inicia;
                paraTerceroO = ini;
            }
            else if (MainWindow.inicia is Separador)
            {
                Separador ini = (Separador)MainWindow.inicia;
                pter = ini;

            }
        }

        private void ter_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow.finaliza = this;
            if (MainWindow.inicia is Input)
            {
                Input ini = (Input)MainWindow.inicia;
                paraSegundo = ini;
            }
            else if (MainWindow.inicia is OutputIntermedio)
            {
                OutputIntermedio ini = (OutputIntermedio)MainWindow.inicia;
                paraSegundoO = ini;
            }
            else if (MainWindow.inicia is Separador)
            {
                Separador ini = (Separador)MainWindow.inicia;
                pseg = ini;

            }
        }
    }
}
