using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text;

namespace BackEnd
{
    public class LineaBackEnd
    {
        Random r = new Random();
        Line redLine;

        Color[] colores = { Colors.AliceBlue,Colors.Blue,Colors.Tan,Colors.Thistle,Colors.PaleTurquoise,Colors.LightGreen,Colors.Gold,Colors.DarkGray,Colors.Chocolate,Colors.AliceBlue, Colors.AntiqueWhite, Colors.Aquamarine, Colors.Black, Colors.Brown, Colors.BlueViolet, Colors.Red };
        

        public bool CreateALine(Point positi, Point posicion, int cual, Canvas uf /*Canvas operacion*/)
        {
            int u = r.Next(0, colores.Length);
            redLine = new Line();
            redLine.X1 = positi.X;
            redLine.Y1 = positi.Y ;
            redLine.X2 = posicion.X;
            redLine.Y2 = posicion.Y;
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = colores[u];
            redLine.StrokeThickness = 4;
            redLine.Stroke = redBrush;
            uf.Children.Add(redLine);
            //operacion.Children.Add(redLine);
            return true;

        }
        public void borraTe(Canvas uf)
        {
            uf.Children.Remove(redLine);
        }
    }
}
