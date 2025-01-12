using System;
using System.Runtime.InteropServices;

namespace LegacyFighter.Dietary.Models.NewProducts
{
    /// <summary>
    /// Produkt dietetycznej ¿ywnoœci
    /// </summary>
    public class OldProduct
    {
        /// <summary>
        /// Numery seryjny produktu
        /// </summary>
        public Guid SerialNumber { get; private set; } = Guid.NewGuid();

        /// <summary>
        /// Cena produktu
        /// </summary>
        public decimal? Price { get; private set; }

        /// <summary>
        /// Krótki opis produktu
        /// </summary>
        public string Desc { get; private set; }

        /// <summary>
        /// D³ugi opis produktu
        /// </summary>
        public string LongDesc { get; private set; }

        /// <summary>
        /// Stan magazynowy produktu
        /// </summary>
        public int? Counter { get; private set; }

        public OldProduct(decimal? price, string desc, string longDesc, int? counter)
        {
            Price = price;
            Desc = desc;
            LongDesc = longDesc;
            Counter = counter;
        }

        /// <summary>
        /// Ustawianie stanu magazynowego
        /// </summary>
        /// <param name="amount"></param>
        public void SetCounter(int amount)
        {
            if(Counter == null)
                Counter = amount;
        }

        /// <summary>
        /// Zmiejszanie stanu magazynowego
        /// </summary>
        public void DecrementCounter() => ChangerCounter(false);

        /// <summary>
        /// Zwiêkszanie stanu magazynowego
        /// </summary>
        public void IncrementCounter() => ChangerCounter(true);

        /// <summary>
        /// Zmieñ cenê produktu
        /// </summary>
        public void ChangePriceTo(decimal? newPrice)
        {
            if (Counter == null)
            {
                throw new InvalidOperationException("null counter");
            }

            if (Counter > 0)
            {
                if (newPrice == null)
                {
                    throw new InvalidOperationException("new price null");
                }

                Price = newPrice;
            }
        }

        /// <summary>
        /// Zmieñ literkê w opisach (ta metoda wgl ma sens?)
        /// </summary>
        public void ReplaceCharFromDesc(string charToReplace, string replaceWith)
        {
            if (ValidateDescriptions())
            {
                throw new InvalidOperationException("null or empty desc");
            }

            LongDesc = LongDesc.Replace(charToReplace, replaceWith);
            Desc = Desc.Replace(charToReplace, replaceWith);
        }

        /// <summary>
        /// Zwróæ oba opisy
        /// </summary>
        public string FormatDesc()
        {
            if (ValidateDescriptions())
            {
                return "";
            }

            return Desc + " *** " + LongDesc;
        }

        /// <summary>
        /// Walidacja opisów
        /// </summary>
        private bool ValidateDescriptions()
        {
            return string.IsNullOrWhiteSpace(LongDesc) || string.IsNullOrWhiteSpace(Desc);
        }

        /// <summary>
        /// Zmiana stanu magazynowego
        /// </summary>
        private void ChangerCounter(bool increment)
        {
            if (Price is not null && Price > 0)
            {
                if (Counter == null)
                {
                    throw new InvalidOperationException("null counter");
                }

                Counter = increment == true ? Counter + 1 : Counter - 1; 
                if (Counter < 0)
                {
                    throw new InvalidOperationException("Negative counter");
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid price");
            }
        }
    }
}