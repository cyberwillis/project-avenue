using System;
using System.Threading;
using AvenueEntrega.RepositoryFile.Converters;
using FileHelpers;

namespace AvenueEntrega.RepositoryFile.Dto
{
    [DelimitedRecord(" ")]
    public class RotaRepositoryDto
    {
        public string Origem;

        public string Destino;
        
        //[FieldConverter(typeof(ValueConverter))]
        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Custo;
    }
}