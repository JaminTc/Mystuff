using System;
using System.Collections.Generic;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;
using System.IO;

namespace FlooringProgram.Data.TaxRates
{
    public class TaxRateFileRepository : ITaxRateRepository
    {
        public List<TaxRate> GetTaxRates()
        {
            List<TaxRate> rates = new List<TaxRate>();
            decimal Tax = 0.00m;
            string[] data = File.ReadAllLines(@"Data\Orders\Taxes.txt");
            for (int i = 1; i < data.Length; i++)
            {
                string[] row = data[i].Split(',');

                TaxRate toAdd = new TaxRate();
                toAdd.State = row[0];
                var IsTax = decimal.TryParse(row[1], out Tax);
                toAdd.TaxPercent = Tax;

                rates.Add(toAdd);
            }

            return rates;
        }
    }
}
