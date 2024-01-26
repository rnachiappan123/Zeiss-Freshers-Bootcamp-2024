using System;
using System.Linq;
using System.Text;

namespace FreshersBootcamp
{
    class Product
    {
        private string name;

        private int productID;
        private int stock;

        private byte gst;
        private byte discount;

        private double price;
        private double taxPrice;
        private double discountedPrice;
        private double totalPrice;

        private DateTime mfgDate;

        public int ProductID
        {
            get { return productID; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Product ID must be greater than 0");
                }
                productID = value;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.Length < 4)
                {
                    throw new ArgumentOutOfRangeException("Name must be atleast 4 characters long");
                }
                name = value;
            }
        }

        public DateTime MfgDate
        {
            get { return mfgDate; }
            set
            {
                if (DateTime.Compare(value, DateTime.Now) > 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid date of manufacturing");
                }
                mfgDate = value;
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentOutOfRangeException("Price must be greater than 0");
                }
                price = value;
            }
        }

        public int Stock
        {
            get { return stock; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Stock must be greater than 0");
                }
                stock = value;
            }
        }

        public byte Gst
        {
            get { return gst; }
            set
            {
                if (!new []{ 5, 12, 18, 28 }.Contains(value))
                {
                    throw new ArgumentOutOfRangeException("GST must be 5, 12, 18 or 28");
                }
                gst = value;
            }
        }

        public byte Discount
        {
            get { return discount; }
            set
            {
                if ((value < 2) || (value > 30))
                {
                    throw new ArgumentOutOfRangeException("Discount must be between 2 to 30");
                }
                discount = value;
            }
        }

        public void CalculatePrices()
        {
            taxPrice = Price + (Price * Gst / 100);
            discountedPrice = taxPrice - (taxPrice * Discount / 100);
            totalPrice = discountedPrice * Stock;
        }

        public string Display()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Product ID: " + ProductID.ToString());
            sb.AppendLine("Product Name: " + Name);
            sb.AppendLine("Date of Manufacturing: " + MfgDate.ToString());
            sb.AppendLine("Tax Price: " + taxPrice);
            sb.AppendLine("Discount Price: " + discountedPrice);
            sb.AppendLine("Total Price: " + totalPrice);

            return sb.ToString();
        }
    }
}