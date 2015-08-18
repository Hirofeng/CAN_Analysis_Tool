using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace Fengyuan.DBCResolver
{
    public class DbcMessage:Collection<DbcSignal>
    {
        private string _name;
        private byte _size;
        private ushort _id;

        /// <summary>
        /// CAN消息名称属性
        /// </summary>
        public string MessageName
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// CAN消息ID属性
        /// </summary>
        public ushort MessageId
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// CAN消息长度属性
        /// </summary>
        public byte MessageSize
        {
            get { return _size; }
            set { _size = value; }
        }


        //TODO 存入CAN data,计算所包含的每个消息的值
        public void AddMessageDatas(byte[] datas,byte length)
        {
            foreach (DbcSignal signal in base.Items)
            {
                signal.RawValue = 0;
                for (byte i = 0; i < signal.Size; i++)
                {
                    signal.RawValue |= (ushort)(GetBitValue(datas, (byte)(signal.StartBit + i)) << (signal.Size - i - 1));
                    
                }
                Console.WriteLine(signal.SignalName + signal.RawValue);
            }
            
        }

       

        private byte GetBitValue(byte[] datas, byte bitPosition)
        {
            byte dataIndex;
            byte bitIndex;
            byte temp;
            dataIndex = (byte)(bitPosition/8);
            bitIndex = (byte)(7 - (bitPosition%8));
            temp = (byte) (datas[dataIndex] >> bitIndex);
            return (byte)(temp & 0x01);

        }





        public DbcMessage(string name)
        {
            _name = name;

        }

        public DbcSignal Add(string signalName)
        {
            DbcSignal signalObject = new DbcSignal(signalName);
            base.Add(signalObject);
            return signalObject;
        }


        public new void Add(DbcSignal signal)
        {
            base.Add(signal);
        }



    }
}
