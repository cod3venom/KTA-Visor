// Decompiled with JetBrains decompiler
// Type: USBKitcs.Descriptors.LangStringDescriptor
// Assembly: USBKitcs, Version=2.2.8.104, Culture=neutral, PublicKeyToken=null
// MVID: A6F2FD20-562E-44D1-8EEB-F4E507ACD1C2
// Assembly location: C:\Program Files\BELL Tronics\Falcon Setup Manager 1.0\USBKitcs.dll

using System.Runtime.InteropServices;
using System.Text;

namespace USBKitcs.Descriptors
{
  internal class LangStringDescriptor : UsbMemChunk
  {
    private static readonly int OfsDescriptorType = Marshal.OffsetOf(typeof (UsbDescriptor), nameof (DescriptorType)).ToInt32();
    private static readonly int OfsLength = Marshal.OffsetOf(typeof (UsbDescriptor), nameof (Length)).ToInt32();

    public LangStringDescriptor(int maxSize)
      : base(maxSize)
    {
    }

    public DescriptorType DescriptorType
    {
      get => (DescriptorType) Marshal.ReadByte(this.Ptr, LangStringDescriptor.OfsDescriptorType);
      set => Marshal.WriteByte(this.Ptr, LangStringDescriptor.OfsDescriptorType, (byte) value);
    }

    public byte Length
    {
      get => Marshal.ReadByte(this.Ptr, LangStringDescriptor.OfsLength);
      set => Marshal.WriteByte(this.Ptr, LangStringDescriptor.OfsLength, value);
    }

    public bool Get(out short[] langIds)
    {
      langIds = new short[0];
      int length1 = (int) this.Length;
      if (length1 <= 2)
        return false;
      int length2 = (length1 - 2) / 2;
      langIds = new short[length2];
      int size = UsbDescriptor.Size;
      for (int index = 0; index < langIds.Length; ++index)
        langIds[index] = Marshal.ReadInt16(this.Ptr, size + 2 * index);
      return true;
    }

    public bool Get(out byte[] bytes)
    {
      bytes = new byte[(int) this.Length];
      Marshal.Copy(this.Ptr, bytes, 0, bytes.Length);
      return true;
    }

    public bool Get(out string str)
    {
      str = string.Empty;
      byte[] bytes;
      if (!this.Get(out bytes))
        return false;
      str = bytes.Length > UsbDescriptor.Size ? Encoding.Unicode.GetString(bytes, UsbDescriptor.Size, bytes.Length - UsbDescriptor.Size) : string.Empty;
      return true;
    }
  }
}
