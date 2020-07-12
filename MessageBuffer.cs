using System.Collections.Generic;

namespace BurglarOfBabylon
{
    public class MessageBuffer
    {
        private readonly string[] buffer;
        private int index;

        public MessageBuffer(int size)
        {
            buffer = new string[size];
            index = 0;
        }

        public void Push(string msg)
        {
            buffer[index++] = msg;
            if (index >= buffer.Length)
            {
                index = 0;
            }
        }

        public IEnumerable<string> GetMessages()
        {
            var size = buffer.Length;
            for (var i = 0; i < size; i++)
            {
                yield return buffer[(index - 1 - i + size) % size] ?? string.Empty;
            }
        }
    }
}
