// Type: System.IO.BinaryReader
// Assembly: mscorlib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace System.IO
{
    [ComVisible(true)]
    public class BinaryReader : IDisposable
    {
        public BinaryReader(Stream input);
        public BinaryReader(Stream input, Encoding encoding);
        public virtual Stream BaseStream { get; }

        #region IDisposable Members

        void IDisposable.Dispose();

        #endregion

        public virtual void Close();
        protected virtual void Dispose(bool disposing);
        public virtual int PeekChar();
        public virtual int Read();
        public virtual bool ReadBoolean();
        public virtual byte ReadByte();

        [CLSCompliant(false)]
        public virtual sbyte ReadSByte();

        public virtual char ReadChar();
        public virtual short ReadInt16();

        [CLSCompliant(false)]
        public virtual ushort ReadUInt16();

        public virtual int ReadInt32();

        [CLSCompliant(false)]
        public virtual uint ReadUInt32();

        public virtual long ReadInt64();

        [CLSCompliant(false)]
        public virtual ulong ReadUInt64();

        public virtual float ReadSingle();
        public virtual double ReadDouble();
        public virtual decimal ReadDecimal();
        public virtual string ReadString();
        public virtual int Read(char[] buffer, int index, int count);
        public virtual char[] ReadChars(int count);
        public virtual int Read(byte[] buffer, int index, int count);
        public virtual byte[] ReadBytes(int count);
        protected virtual void FillBuffer(int numBytes);
        protected internal int Read7BitEncodedInt();
    }
}
