using System;

namespace ConsoleApp2
{
    class ElementNotFoundException : Exception
    {
        public override string Message { get; }

        public ElementNotFoundException()
        {
            Message = "Элемент не найден";
        }
    }
}
