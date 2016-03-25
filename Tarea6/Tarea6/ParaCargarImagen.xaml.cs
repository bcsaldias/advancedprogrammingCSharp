using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tarea6
{
    /// <summary>
    /// Lógica de interacción para ParaCargarImagen.xaml
    /// </summary>
    public partial class ParaCargarImagen : Window
    {
        public string pathImageN;
        public ParaCargarImagen()
        {
            //OpenFileDialog d = new OpenFileDialog();
            //d.ShowDialog();
            //string a = d.FileName;
            ////d.DefaultExt
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            pathImageN = "a";//textBox1.Text;
            this.Close();
        }
    }
}
