﻿using ProjectManager.Core.Common.Contracts;

namespace ProjectManager.Core.Common.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object value)
        {
            Console.Write(value);
        }

        public void WriteLine(object value)
        {
            Console.WriteLine(value);
        }
    }
}
