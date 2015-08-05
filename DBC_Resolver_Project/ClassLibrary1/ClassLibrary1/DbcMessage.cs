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



    }
}
