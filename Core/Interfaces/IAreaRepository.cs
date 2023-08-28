using Core.Entidades;
using System.Collections.Generic;

namespace Core.Interfaces
{
    public interface IAreaRepository : IGenericRepository<Area> 
    {

        Task<Area> GetBYIdConDepartamento(int id);
        Task<IReadOnlyList<Usuario>> GetUsuariosPorId(int id);

        Task<IReadOnlyList<Publicacion>> GetPublicacionId(int id);
    }
}
