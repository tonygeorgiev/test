using Bytes2you.Validation;
using ProjectManager.Core.Common.Contracts;

namespace ProjectManager.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IProcessor processor;

        public Engine(IReader reader, IWriter writer, IProcessor processor)
        {
            if(processor == null)
            {
                throw new ArgumentNullException();
            }

            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.processor = processor;
        }

        public string Start(string input)
        { 
            return this.processor.ProcessCommand(input);
        }
    }
}
