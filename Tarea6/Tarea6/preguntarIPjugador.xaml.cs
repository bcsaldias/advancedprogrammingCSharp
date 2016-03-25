using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using BackEnd;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para preguntarIPjugador.xaml
    /// </summary>
    public partial class preguntarIPjugador : Window
    {
        string nick;
        public preguntarIPjugador(string nick)
        {
            this.nick = nick;
            InitializeComponent();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MW uno = new MW(2, nick, /*cargIm.pathImageN*/"a", 0, textBox1.Text);
            uno.Show();
            this.Close();
        }
    }
}
