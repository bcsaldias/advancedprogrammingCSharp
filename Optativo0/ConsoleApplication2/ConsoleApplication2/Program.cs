using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace

ConsoleApplication1
{

    public class Program
    {

        static void Main(string[] args)
        {

            Item[] tienda1 = new Item[13]; // productos de la tienda
            tienda1[0] = new Item(10000, "Mouse", "Dell");
            tienda1[1] = new Item(15500, "Teclado", "Olidata");
            tienda1[2] = new Item(9990, "Funda notebook", "Dell");
            tienda1[3] = new Item(19999, "Parlantes", "Toshiba");
            tienda1[4] = new Item(9900, "Mouse", "HP");
            tienda1[5] = new Item(10000, "Tablet 17'' ", "Samsung");
            tienda1[6] = new PC(720000, "Computador", "Samsung", 0);
            tienda1[7] = new PC(780000, "Computador", "Samsung", 1);
            tienda1[8] = new PC(850000, "Computador", "Samsung", 3);
            tienda1[9] = new PC(320000, "Netbook", "Compac", 0);
            tienda1[10] = new PC(325000, "Netbook", "Compac", 1);
            tienda1[11] = new PC(360000, "Netbook", "Compac", 2);
            tienda1[12] = new PC(400000, "Netbook", "Compac", 3);
            Tienda tiendaPrincipal = new Tienda(tienda1);



            Item[] paraOrden1 = new Item[3];
            paraOrden1[0] = tienda1[1];
            paraOrden1[1] = tienda1[6];
            paraOrden1[2] = tienda1[4];

            Cliente cliente1 = new Cliente("Rafael","9.452.161-1");
            cliente1.hacerPedido(cliente1, "enero", paraOrden1, tiendaPrincipal);

            Item[] paraOrden2 = new Item[3];
            paraOrden2[0] = tienda1[0];
            paraOrden2[1] = tienda1[1];
            paraOrden2[2] = tienda1[2];

            Cliente cliente2 = new Cliente("Carolina","11.252.484-7");
            cliente2.hacerPedido(cliente2,"febrero", paraOrden2, tiendaPrincipal);

            Item[] paraOrden3 = new Item[4];
            paraOrden3[0] = tienda1[2];
            paraOrden3[1] = tienda1[5];
            paraOrden3[2] = tienda1[0];
            paraOrden3[3] = tienda1[11];

            Cliente cliente3 = new Cliente("Andrea", "17.355.244-K");
            cliente3.hacerPedido(cliente3,"enero", paraOrden3, tiendaPrincipal);

            Console.WriteLine("Escriba en minúscula el nombre del mes del que \ndesea ver las ordenes de compra y presione Enter. \nSolo hay orndenes de: enero y febrero \nMes:");
            string mes = Console.ReadLine();
            tiendaPrincipal.imprimirOCmes(mes);
       

            Console.Read();
        }

    }
}