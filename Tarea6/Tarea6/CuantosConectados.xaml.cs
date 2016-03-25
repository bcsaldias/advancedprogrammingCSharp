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
using System.Net;
using System.Net.Sockets;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para CuantosConectados.xaml
    /// </summary>
    public partial class CuantosConectados : Window
    {
        int a, maxConectados;
        string nick, pathImageN;
        public CuantosConectados(int a, string nick, string pathImageN, int maxConectados)
        {
            InitializeComponent();
//// esta es la q le copio
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress dir = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            MessageBox.Show("IPAddress del Servidor: " + dir.ToString());
        ///
            this.a = a;
            this.nick = nick;
            this.pathImageN = pathImageN;
            this.maxConectados = maxConectados;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MW uno = new MW(1, nick, pathImageN, 1,"a");
            uno.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MW uno = new MW(1, nick, pathImageN, 2,"a");
            uno.Show();
            this.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            MW uno = new MW(1, nick, pathImageN, 3, "a");
            uno.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            MW uno = new MW(1, nick, pathImageN, 4, "a");
            uno.Show();
            this.Close();
        }
    }
}
