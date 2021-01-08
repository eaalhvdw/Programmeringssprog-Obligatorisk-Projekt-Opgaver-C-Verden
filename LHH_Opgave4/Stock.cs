namespace LHH_Opgave4
{
    public class Stock
    {
        private string symbol;
        private decimal price;

        // Delegate Eventhandler
        public delegate void PriceChangedHandler(object sender, decimal oldPrice, decimal price);
        // Events
        public event PriceChangedHandler PriceIncreased;
        public event PriceChangedHandler PriceDecreased;

        public Stock(string symbol)
        {
            this.symbol = symbol;
        }

        public decimal Price
        {
            get { return price; }

            set
            {
                if (price == value)
                {
                    return; // Exit if nothing has changed.
                }

                decimal oldPrice = price;
                price = value;

                // Evaluate which event to raise.
                if (oldPrice < price)
                {
                    PriceIncreased?.Invoke(this, oldPrice, price);
                }
                else
                {
                    PriceDecreased?.Invoke(this, oldPrice, price);
                }
            }
        }
    }
}
