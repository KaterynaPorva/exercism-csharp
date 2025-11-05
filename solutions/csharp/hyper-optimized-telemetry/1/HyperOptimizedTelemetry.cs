using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        byte[] buffer = new byte[9];
        byte[] payload;
        byte prefix;

        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            payload = BitConverter.GetBytes((ushort)reading);
            prefix = 2; 
        }
        else if (reading >= 65_536 && reading <= int.MaxValue)
        {
            payload = BitConverter.GetBytes((int)reading);
            prefix = (byte)(256 - 4); 
        }
        else if (reading >= 2_147_483_648 && reading <= uint.MaxValue)
        {
            payload = BitConverter.GetBytes((uint)reading);
            prefix = 4; 
        }
        else if (reading >= 4_294_967_296 && reading <= long.MaxValue)
        {
            payload = BitConverter.GetBytes((long)reading);
            prefix = (byte)(256 - 8); 
        }
        else if (reading >= -32_768 && reading <= -1)
        {
            payload = BitConverter.GetBytes((short)reading);
            prefix = (byte)(256 - 2); 
        }
        else if (reading >= -2_147_483_648 && reading <= -32_769)
        {
            payload = BitConverter.GetBytes((int)reading);
            prefix = (byte)(256 - 4); 
        }
        else if (reading >= long.MinValue && reading <= -2_147_483_649)
        {
            payload = BitConverter.GetBytes((long)reading);
            prefix = (byte)(256 - 8); 
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(reading));
        }

        buffer[0] = prefix;
        Array.Copy(payload, 0, buffer, 1, payload.Length);
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 2)
            throw new ArgumentException("Buffer too small");

        byte prefix = buffer[0];
        bool isSigned = prefix > 128;
        int length = isSigned ? 256 - prefix : prefix;

        if (length != 2 && length != 4 && length != 8)
        {
            return 0;
        }

        if (buffer.Length < 1 + length)
        {
            return 0;
        }

        byte[] payload = new byte[8];
        Array.Copy(buffer, 1, payload, 0, length);

        if (isSigned)
        {
            return length switch
            {
                2 => BitConverter.ToInt16(payload, 0),
                4 => BitConverter.ToInt32(payload, 0),
                8 => BitConverter.ToInt64(payload, 0),
                _ => 0
            };
        }
        else
        {
            return length switch
            {
                2 => BitConverter.ToUInt16(payload, 0),
                4 => BitConverter.ToUInt32(payload, 0),
                8 => (long)BitConverter.ToUInt64(payload, 0),
                _ => 0
            };
        }
    }
}
