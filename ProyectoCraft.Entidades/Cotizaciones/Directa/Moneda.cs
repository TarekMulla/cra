using System;
using ProyectoCraft.Entidades.GlobalObject;

namespace ProyectoCraft.Entidades.Cotizaciones.Directa {
    public class Moneda : NamedObject,IConvertible {
        public String Codigo { set; get; }
        public Boolean Activo { set; get; }
        public TypeCode GetTypeCode() {
            throw new NotImplementedException();
        }

        public bool ToBoolean(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public char ToChar(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public sbyte ToSByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public byte ToByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public short ToInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public ushort ToUInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public int ToInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public uint ToUInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public long ToInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public ulong ToUInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public float ToSingle(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public double ToDouble(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public decimal ToDecimal(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public DateTime ToDateTime(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        public string ToString(IFormatProvider provider) {
            return Codigo;
        }

        public object ToType(Type conversionType, IFormatProvider provider) {
            throw new NotImplementedException();
        }
    }
}