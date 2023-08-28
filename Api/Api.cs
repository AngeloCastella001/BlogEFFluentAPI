using Core.Entidades;
using Core.Interfaces;
using NPOI.Util;
using System;

namespace Api
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication web) 
        {
            web.MapGet("/", () => "Hola Angelo");

            //Areas
            web.MapGet("/areas", ConsultarAreas);
            web.MapGet("/areaspaginacion", ConsultarAreasPaginacion);
            web.MapGet("/areas/{id}", ConsultarAreaPorId);
            web.MapGet("/areas/{id}/departamentos", DepartamentosPorArea);
            web.MapGet("/areas/{id}/usuarios", UsuariosPorArea);
            web.MapGet("/areas/{id}/publicaciones", PublicacionPorArea);
            web.MapPost("/areas", AgregarArea);
            web.MapPost("/areas/batch", AgregarAreas);
            web.MapPut("/areas/{id}", ActualizarAreaPorId);
            web.MapDelete("/areas/{id}", EliminarAreaPorId);
        }

        #region Areas

        private static async Task<IResult> AgregarAreas(IUnitOfWork unit, List<Area> areaList)
        {
            try
            {
                unit.AreaRepository.AddRange(areaList);
                await unit.SaveAsync();

                return Results.Ok(areaList);

            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static async Task<IResult> PublicacionPorArea(IUnitOfWork unit, int id)
        {
            try
            {
                var area = await unit.AreaRepository.GetByIdAsync(id);
                if (area == null) { return Results.NotFound(); }
                var publicaciones = await unit.AreaRepository.GetPublicacionId(area.Id);
                return Results.Ok(new
                {
                    area,
                    publicaciones
                });
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static async Task<IResult> UsuariosPorArea(IUnitOfWork unit, int id)
        {
            try
            {
                var area = await unit.AreaRepository.GetByIdAsync(id);
                if (area == null) { return Results.NotFound(); }
                var usuarios = await unit.AreaRepository.GetUsuariosPorId(area.Id);
                return Results.Ok(new
                {
                    area,usuarios
                });
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        private static async Task<IResult> DepartamentosPorArea(IUnitOfWork unit, int id)
        {
            try
            {
                var area = await unit.AreaRepository.GetBYIdConDepartamento(id);
                if (area == null) { return Results.NotFound(); }

                return Results.Ok(area);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        private static async Task<IResult> EliminarAreaPorId(IUnitOfWork unit, int id)
        {
            try
            {
                var areas = await unit.AreaRepository.GetByIdAsync(id);
                if (areas == null) { return Results.NotFound(); }

                unit.AreaRepository.Remove(areas);
                await unit.SaveAsync();

                return Results.Ok(areas);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        private static async Task<IResult> ActualizarAreaPorId(IUnitOfWork unit, int id, Area area)
        {
            try
            {
                unit.AreaRepository.Update(area);
                await unit.SaveAsync();
                return Results.Ok(area);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        private static async Task<IResult> AgregarArea(IUnitOfWork unit, Area area)
        {
            try
            {
                unit.AreaRepository.Add(area);
                await unit.SaveAsync();
                return Results.Ok(area);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        private static async Task<IResult> ConsultarAreasPaginacion(IUnitOfWork unit, int pageIndex, int pageSize, 
            string search)
        {
            try
            {
                var areas = await unit.AreaRepository.GetAllAsync(pageIndex, pageSize, search);

                

                return Results.Ok(new 
                {
                    areas.totalRegistros,
                    areas.registros
                });
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        private static async Task<IResult> ConsultarAreaPorId(IUnitOfWork unit, int id)
        {
            try
            {
                var areas = await unit.AreaRepository.GetByIdAsync(id);

                if (areas == null) { return Results.NotFound(); }

                return Results.Ok(areas);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }

        private static async Task<IResult> ConsultarAreas(IUnitOfWork unit)
        {
            try
            {
                var areas = await unit.AreaRepository.GetAllAsync();
                return Results.Ok(areas);
            }
            catch (Exception e)
            {
                return Results.Problem(e.Message);
            }
        }
        #endregion
    }
}
