namespace DemoCode.Calculator
{
    public class DecimalCalculator : ICalculator<decimal>
    {
        private decimal _value;

        public decimal Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
            }
        }

        public void Subtract(decimal number)
        {
            Value -= number;
        }

        public void Add(decimal number)
        {
            Value += number;
        }
    }
}