using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repository
{
    public class AreaRepository : GenericRepository<Area>, IAreaRepository
    {
        public AreaRepository(BlogContext context) : base(context)
        {

        }

        public async Task<Area> GetBYIdConDepartamento(int id)
        {
            return await _context.Areas.Include(u => u.Departamentos).FirstOrDefaultAsync(u=>u.Id==id);
        }

        public async Task<IReadOnlyList<Publicacion>> GetPublicacionId(int id)
        {
            var ver = await _context.Areas.Include(u => u.Departamentos)
                .ThenInclude(u => u.Usuarios)
                .ThenInclude(u => u.Publicaciones)
                .Where(u => u.Id == id)
                .SelectMany(u=>u.Departamentos
                .SelectMany(u=>u.Usuarios
                .SelectMany(u=>u.Publicaciones))).ToListAsync();

            return ver;
        }

        public async Task<IReadOnlyList<Usuario>> GetUsuariosPorId(int id)
        {
            var ver = await _context.Areas.Include(u => u.Departamentos)
                .ThenInclude(u=>u.Usuarios)
                .Where(u=>u.Id==id).SelectMany(u=>u.Departamentos.SelectMany(u=>u.Usuarios)).ToListAsync();
            return ver;
        }
    }
}
