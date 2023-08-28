using Core.Interfaces;
using Infraestructura.Data;
using Infraestructura.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BlogContext _context;
        private IAreaRepository _area;
        private IComentarioRepository _comentario;
        private IDepartamentoRepository _departamento;
        private IPerfilRepository _perfil;
        private IPublicacionRepository _publicacion;
        private IUsuarioRepository _usuario;
        public UnitOfWork(BlogContext context) 
        {
            _context = context;
        }

        public IAreaRepository AreaRepository
        { 
            get 
            { 
                if (_area == null) 
                {
                    _area = new AreaRepository(_context);
                }
                return _area; 
            } 
        }

        public IComentarioRepository ComentarioRepository
        {
            get
            {
                if (_comentario == null)
                {
                    _comentario = new ComentarioRepository(_context);
                }
                return _comentario;
            }
        }

        public IDepartamentoRepository DepartamentoRepository
        {
            get
            {
                if (_departamento == null)
                {
                    _departamento = new DepartamentoRepository(_context);
                }
                return _departamento;
            }
        }

        public IPerfilRepository PerfilRepository
        {
            get
            {
                if (_perfil == null)
                {
                    _perfil = new PerfilRepository(_context);
                }
                return _perfil;
            }
        }

        public IPublicacionRepository PublicacionRepository
        {
            get
            {
                if (_publicacion == null)
                {
                    _publicacion = new PublicacionRepository(_context);
                }
                return _publicacion;
            }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (_usuario == null)
                {
                    _usuario = new UsuarioRepository(_context);
                }
                return _usuario;
            }
        }

        public async Task<int> SaveAsync() 
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
