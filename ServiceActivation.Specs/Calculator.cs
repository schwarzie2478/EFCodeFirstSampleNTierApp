using System;

namespace ServiceActivation.Specs
{
    internal class Calculator
    {
        internal int FirstNumber;
        private int? _result ;
        internal  int Result
        {
            get
            {
                return _result.GetValueOrDefault(0);
            }
        }
        internal int SecondNumber;

        internal void AddPressed()
        {
            _result = FirstNumber + SecondNumber;
        }
    }
}