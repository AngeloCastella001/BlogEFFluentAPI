using Core.Entidades;
using Infraestructura.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json;

namespace Api.Helpers;
public class BlogContextSeed
{    
    public static async Task SeedAsync(BlogContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            await context.Database.OpenConnectionAsync();
           
           /* context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Area ON");
            if (!context.Areas.Any())
            {
                var areasData = File.ReadAllText(ruta + @"/JsonData/areas.json");
                var areas = JsonSerializer.Deserialize<List<Area>>(areasData);             

                await context.Areas.AddRangeAsync(areas);
                await context.SaveChangesAsync();
             
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Area OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Departamento ON");
            if (!context.Departamentos.Any())
            {
                var departamentosData = File.ReadAllText(ruta + @"/JsonData/departamentos.json");
                var departamentos = JsonSerializer.Deserialize<List<Departamento>>(departamentosData);
              
                await context.Departamentos.AddRangeAsync(departamentos);
                await context.SaveChangesAsync();
              
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Departamento OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Perfil ON");
            if (!context.Perfiles.Any())
            {

                var perfilesData = File.ReadAllText(ruta + @"/JsonData/perfiles.json");
                var perfiles = JsonSerializer.Deserialize<List<Perfil>>(perfilesData);                
                context.Perfiles.AddRange(perfiles);
                await context.SaveChangesAsync();
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Perfil OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Usuario ON");
            if (!context.Usuarios.Any())
            {
                var usuariosData = File.ReadAllText(ruta + @"/JsonData/usuarios.json");
                var usuarios = JsonSerializer.Deserialize<List<Usuario>>(usuariosData);
                
                foreach (var usuario in usuarios)
                {
                    usuario.EncargadoId = usuario.EncargadoId > 0 ? usuario.EncargadoId : null;
                    context.Usuarios.Add(usuario);
                    await context.SaveChangesAsync();
                }
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Usuario OFF");
        

            if (!context.UsuariosPerfiles.Any())
            {

                var daUsuariosPerfilesData = File.ReadAllText(ruta + @"/JsonData/usuarios_perfiles.json");
                var daUsuariosPerfiles = JsonSerializer.Deserialize<List<UsuarioPerfil>>(daUsuariosPerfilesData);

                await context.UsuariosPerfiles.AddRangeAsync(daUsuariosPerfiles);
                await context.SaveChangesAsync();                
            }

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Publicacion ON");
            if (!context.Publicaciones.Any())
            {
                var publicacionesData = File.ReadAllText(ruta + @"/JsonData/publicaciones.json");
                var publicaciones = JsonSerializer.Deserialize<List<Publicacion>>(publicacionesData);
                
                await context.Publicaciones.AddRangeAsync(publicaciones);
                await context.SaveChangesAsync();                
            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Publicacion OFF");

            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Comentario ON");
            if (!context.Comentarios.Any())
            {
                var comentariosData = File.ReadAllText(ruta + @"/JsonData/comentarios.json");
                var comentarios = JsonSerializer.Deserialize<List<Comentario>>(comentariosData);

                var listaComentarios = new List<Comentario>();

                foreach(var comentario in comentarios)
                {
                    listaComentarios.Add(new Comentario
                    {
                        Id = comentario.Id,
                        Asunto = comentario.Asunto,
                        Contenido = comentario.Contenido,
                        Email = comentario.Email,
                        PublicacionId = comentario.PublicacionId,
                        Aprobado = (comentario.Id % 2 == 0) ? true : false
                    });
                }

                await context.Comentarios.AddRangeAsync(comentarios);
                await context.SaveChangesAsync();

            }
            context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.Comentario OFF");*/

           // context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.DatosAdicionalesUsuario ON");
           // if (!context.DatosAdicionalesUsuarios.Any())
            //{
            //    var daUsuariosData = File.ReadAllText(ruta + @"/JsonData/datos_adicionales_usuario.json");
            //    var daUsuarios = JsonSerializer.Deserialize<List<DatosAdicionalesUsuario>>(daUsuariosData);

            //    await context.DatosAdicionalesUsuarios.AddRangeAsync(daUsuarios);
            //    await context.SaveChangesAsync();
           // }
            //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT blog.DatosAdicionalesUsuario OFF");

            //await context.Database.CloseConnectionAsync();


        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<BlogContextSeed>();
            logger.LogError(ex.Message);
        }
    }
}