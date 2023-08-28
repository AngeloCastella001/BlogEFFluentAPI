using Core.Entidades;
using Core.Interfaces;
using Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Repository
{
    public class ComentarioRepository : GenericRepository<Area>, IComentarioRepository
    {
        public ComentarioRepository(BlogContext context) : base(context)
        {
        }
    }
}
