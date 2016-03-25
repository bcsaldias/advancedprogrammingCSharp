using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Net;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para Preguntador.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ParaCargarImagen cargIm;
        public int maxConectados;
        public string nick;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            nick = nickName.Text;

            CuantosConectados cc = new CuantosConectados(1, nick, /*cargIm.pathImageN*/"a", maxConectados);
            cc.Show();
            this.Close();

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            nick = nickName.Text;
            preguntarIPjugador pj = new preguntarIPjugador(nick);
            pj.Show();
            this.Close();
           
        }

        private void botonAvatar_Click(object sender, RoutedEventArgs e)
        {
            //cargIm = new ParaCargarImagen();
            //cargIm.Show();
        }
    }
}
