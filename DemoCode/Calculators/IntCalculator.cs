namespace DemoCode.Calculator
{
    public class IntCalculator : ICalculator<int>
    {
       
        private int _value;

        public int Value 
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

        public void Subtract(int number)
        {
            Value -= number;
        }

        public void Add(int number)
        {
            Value += number;
        }
    }
}
