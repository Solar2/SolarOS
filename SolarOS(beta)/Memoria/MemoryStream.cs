namespace SolarOS_beta_.Memoria
{
    //metodi printi se si aggiunge override dopo usafe si possono utilizzare per tale scopo
    internal class MemoryStream
    {
        unsafe byte* ptr = null;

        public unsafe MemoryStream(int pos)
        {
            ptr = (byte*)pos;
        }

        public unsafe MemoryStream(byte pos)
        {
            ptr = (byte*)pos;
        }

        public unsafe int Read()
        {
            return (int)*ptr;
        }

        public unsafe void Write(byte content)
        {
            *ptr = content;
        }

        public unsafe void Write(int content)
        {
            *ptr = (byte)content;
        }
    }
}
