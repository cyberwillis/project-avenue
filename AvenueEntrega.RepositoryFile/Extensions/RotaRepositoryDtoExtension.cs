using System.Collections.Generic;
using System.Linq;
using AvenueEntrega.RepositoryFile.Dto;

namespace AvenueEntrega.RepositoryFile.Extensions
{
    public static class RotaRepositoryDtoExtension
    {
        public static IList<RotaRepositoryDto> ExpandListaRotasRepositoryDto(this IList<RotaRepositoryDto> rotas)
        {
            var rotasExpanded = new List<RotaRepositoryDto>();

            foreach (var rota in rotas)
            {
                var r1 = new RotaRepositoryDto() { Custo = rota.Custo, Origem = rota.Origem, Destino = rota.Destino };
                var r2 = new RotaRepositoryDto() { Custo = rota.Custo, Origem = rota.Destino, Destino = rota.Origem };

                if (rotasExpanded.Count > 0)
                {
                    //Verificar se ja existe
                    if (rotasExpanded.SingleOrDefault((x) => x.Origem == r1.Origem && x.Destino == r1.Destino) != null)
                        continue;
                }

                rotasExpanded.Add(r1);
                rotasExpanded.Add(r2);
            }

            return rotasExpanded;
        }
    }
}