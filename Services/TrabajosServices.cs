using Microsoft.EntityFrameworkCore;
using System.Linq;
using RegistroTecnicos.DAL;
using System.Linq.Expressions;
using RegistroTecnicos.Models;
using System.Net.Http;

namespace RegistroTecnicos.Services;

public class TrabajosServices
{
    private readonly Contexto Contexto;
    private readonly HttpClient _httpClient;

    public TrabajosServices(Contexto contexto, HttpClient httpClient)
    {
        Contexto = contexto;
        _httpClient = httpClient;
    }

    //Método Existe
    public async Task<bool> Existe(int TrabajoId)
    {
        return await Contexto.Trabajos.AnyAsync(t => t.TrabajoId == TrabajoId);
    }

    //Método Insertar
    private async Task<bool> Insertar(Trabajos trabajo)
    {
        Contexto.Trabajos.Add(trabajo);
        return await Contexto.SaveChangesAsync() > 0;
    }

    //Método Modificar
    private async Task<bool> Modificar(Trabajos trabajo)
    {
        Contexto.Trabajos.Update(trabajo);
        var modificado = await Contexto.SaveChangesAsync() > 0;
        Contexto.Entry(trabajo).State = EntityState.Detached;
        return modificado;
    }

    //Método Guardar
    public async Task<bool> Guardar(Trabajos trabajo)
    {
        if (!await Existe(trabajo.TrabajoId))
            return await Insertar(trabajo);
        else
        {
            return await Modificar(trabajo);
        }
    }

    //Método Eliminar
    public async Task<bool> Eliminar(int id)
    {
        var trabajosEliminados = await Contexto.Trabajos
            .Where(t => t.TrabajoId == id)
            .ExecuteDeleteAsync();
        return trabajosEliminados > 0;
    }

    //Método Buscar
    public async Task<Trabajos?> Buscar(int id)
    {
        return await Contexto.Trabajos
            .Include(t => t.Cliente)
            .Include(t => t.Tecnico)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TrabajoId == id);
    }

    //Método Listar
    public async Task<List<Trabajos>> Listar(Expression<Func<Trabajos, bool>> criterio)
    {
        return await Contexto.Trabajos
            .Include(t => t.Cliente)
            .Include(t => t.Tecnico)
            .Where(criterio)
            .ToListAsync();
    }

    //Método Finalizar Trabajo
    public async Task<bool> FinalizarTrabajo(int trabajoId, TimeSpan tiempo)
    {
        var trabajo = await Buscar(trabajoId);
        if (trabajo != null)
        {
            trabajo.Tiempo = tiempo;
            await Guardar(trabajo);

            //Enviar mensaje de WhatsApp
            var mensaje = $"El trabajo {trabajoId} ya está finalizado.";
            var urlWhatsApp = $"https://api.whatsapp.com/send?phone={trabajo.Cliente.WhatsApp}&text={mensaje}";

            var response = await _httpClient.GetAsync(urlWhatsApp);
                return response.IsSuccessStatusCode;
        }
        return false;
    }
    
       
}
