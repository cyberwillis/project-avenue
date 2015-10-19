using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FileHelpers;

namespace AvenueEntrega.RepositoryFile.Converters
{
    public class ValueConverter : ConverterBase
    {
        private IFormatProvider culture = Thread.CurrentThread.CurrentCulture;

        public override object StringToField(string from)
        {
            return Convert.ToDecimal(Decimal.Parse(from) / 100);
        }

        public override string FieldToString(object fieldValue)
        {
            var valor = (0m).ToString("n", culture);

            if (valor.Contains(","))
                return ((decimal) fieldValue).ToString("n", culture).Replace(",", ".");
            else
                return ((decimal) fieldValue).ToString("n", culture);
        }
    }
}
