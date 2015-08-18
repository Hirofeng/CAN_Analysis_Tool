using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fengyuan.DBCResolver
{
    public class DbcSignal
    {
        private ushort _rawValue;
        private string  _name;
        //private char _multIndicator;//'m'= multiplexer_switch_value
        private byte _startBit;
        private byte _size;
        private char _byteOrder; // '0'=big endian, '1'=little endian
        private char _valueType;//'+'=unsigned, '-'=signed
        private double _factor; 
        private double _offset;
        private double _minimum;
        private double _maximum;


        public ushort RawValue
        {
            get { return _rawValue; }
            set { _rawValue = value; }
        }

        /// <summary>
        /// 信号名称属性
        /// </summary>
        public string SignalName
        {
            get { return _name; }
        }
        /// <summary>
        /// 信号长度属性
        /// </summary>
        public byte Size
        {
            get { return _size; }
            set { _size = value; }
        }
        /// <summary>
        /// 信号起始位属性
        /// </summary>
        public byte StartBit
        {
            get { return _startBit; }
            set { _startBit = value; }
        }
        /// <summary>
        /// 信号最小物理值属性
        /// </summary>
        public double Minimum
        {
            get { return _minimum; }
            set { _minimum = value; }
        }

        /// <summary>
        /// 信号最大物理值属性
        /// </summary>
        public double Maximum
        {
            get { return _maximum; }
            set { _maximum = value; }
        }
        /// <summary>
        /// 信号物理值-原始值之间转换的系数因子
        /// </summary>
        public double Factor
        {
            get { return _factor; }
            set { _factor = value; }
        }
        /// <summary>
        /// 信号物理值-原始值之间转换的偏移量
        /// </summary>
        public double Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }



        public DbcSignal(string name)
        {
            _name = name;

        }
        /// <summary>
        /// 信号原始值转换为物理值
        /// </summary>
        /// <param name="rawValue"></param>
        /// <returns></returns>
        public double RawValue2PhysicalValue(int rawValue)
        {
            return (rawValue * _factor + _offset);
        }
        /// <summary>
        /// 信号物理值转换为原始值
        /// </summary>
        /// <param name="physicalValue"></param>
        /// <returns></returns>
        public int PhysicalValue2RawValue(double physicalValue)
        {
            return (int)((physicalValue - _offset) / _factor);
        }
    }
}
