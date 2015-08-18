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
            byte[] datas = {0xB4,0XE5,0x93};
            DbcMessage msg = new DbcMessage("MESSAGE");




           DbcSignal signal = msg.Add("signal1 ");
            signal.StartBit = 0;
            signal.Size = 4;

            DbcSignal signal1 = msg.Add("signal2 ");
            signal1.StartBit = 8;
            signal1.Size = 9;

         //   msg.Add("signal2");
          //  msg.Add("signal3");
            msg.AddMessageDatas(datas, 3);
            Console.ReadKey();
        }
    }
}
