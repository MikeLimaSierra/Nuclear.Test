using System;
using System.IO;
using System.IO.Pipes;
using System.Text;

namespace Nuclear.Test.Extensions {
    public static class PipeStreamExtensions {

        #region read methods

        public static Byte[] ReadLarge(this PipeStream _this) {
            Int32 length = _this.ReadInt32();

            using(MemoryStream ms = new MemoryStream()) {
                for(Int32 i = 0; i < length; i += UInt16.MaxValue) {
                    Byte[] buffer = new Byte[Math.Min(length - i, UInt16.MaxValue)];
                    _this.Read(buffer, 0, buffer.Length);
                    ms.Write(buffer, 0, buffer.Length);
                }

                return ms.ToArray();
            }
        }

        public static String ReadString(this PipeStream _this) {
            Byte[] lengthBuffer = new Byte[sizeof(UInt16)];
            _this.Read(lengthBuffer, 0, lengthBuffer.Length);

            Byte[] valueBuffer = new Byte[BitConverter.ToUInt16(lengthBuffer, 0)];
            _this.Read(valueBuffer, 0, valueBuffer.Length);

            return new UnicodeEncoding().GetString(valueBuffer);
        }

        public static Int32 ReadInt32(this PipeStream _this) {
            Byte[] buffer = new Byte[sizeof(Int32)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToInt32(buffer, 0);
        }

        public static Boolean ReadBoolean(this PipeStream _this) {
            Byte[] buffer = new Byte[sizeof(Boolean)];
            _this.Read(buffer, 0, buffer.Length);
            return BitConverter.ToBoolean(buffer, 0);
        }

        #endregion

        #region write methods

        public static void WriteLarge(this PipeStream _this, Byte[] value) {
            _this.Write(value.Length);

            for(Int32 i = 0; i < value.Length; i += UInt16.MaxValue) {
                _this.Write(value, i, Math.Min(value.Length - i, UInt16.MaxValue));
            }

            _this.Flush();
        }

        public static void Write(this PipeStream _this, String value) {
            Byte[] buffer = new UnicodeEncoding().GetBytes(value);
            UInt16 length = buffer.Length > UInt16.MaxValue ? UInt16.MaxValue : (UInt16) buffer.Length;
            _this.Write(BitConverter.GetBytes(length), 0, sizeof(UInt16));
            _this.Write(buffer, 0, length);
            _this.Flush();
        }

        public static void Write(this PipeStream _this, Int32 value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Int32));
            _this.Flush();
        }

        public static void Write(this PipeStream _this, Boolean value) {
            Byte[] buffer = BitConverter.GetBytes(value);
            _this.Write(BitConverter.GetBytes(value), 0, sizeof(Boolean));
            _this.Flush();
        }

        #endregion

    }
}
