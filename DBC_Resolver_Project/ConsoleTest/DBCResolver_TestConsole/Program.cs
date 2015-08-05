using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fengyuan.DBCResolver;
namespace DBCResolver_TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            DbcManager manager = new DbcManager(@"C:\Users\user\Desktop\CAN.dbc");
            manager.DisplayDbc2Console();


            Console.ReadKey();
        }
    }
}
