using AvenueEntrega.Model.Repository;

namespace AvenueEntrega.Services
{
    public class MalhaServices
    {
        private readonly IMapaRepository _mapaRepository;

        public MalhaServices(IMapaRepository mapaRepository)
        {
            _mapaRepository = mapaRepository;
        }


    }
}
