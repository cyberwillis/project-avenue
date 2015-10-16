using System;
using FileHelpers;

namespace AvenueEntrega.RepositoryFile.Dto
{
    [DelimitedRecord(" ")]
    public class RotaRepositoryDto
    {
        public string Origem;

        public string Destino;

        [FieldConverter(ConverterKind.Decimal, ".")]
        public decimal Custo;
    }
}