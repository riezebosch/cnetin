using System;

namespace AttributeDemo
{
    internal class MijnEigenAttribute : Attribute
    {
        public int Value
        {
            get; private set;
        }


        public MijnEigenAttribute(int value)
        {
            this.Value = value;
        }
    }
}