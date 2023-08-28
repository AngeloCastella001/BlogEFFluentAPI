using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork 
    {
        IAreaRepository AreaRepository { get; }
        IComentarioRepository ComentarioRepository { get; }
        IDepartamentoRepository DepartamentoRepository { get; }
        IPerfilRepository PerfilRepository { get; }
        IPublicacionRepository PublicacionRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
        Task<int> SaveAsync();
    }
}
