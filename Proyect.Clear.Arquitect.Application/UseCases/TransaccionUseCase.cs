using AutoMapper;
using Proyect.Clear.Arquitect.Application.Requests;
using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Proyect.Clear.Arquitect.Application.Requests.EnumTransaccion;

namespace Proyect.Clear.Arquitect.Application.UseCases
{
    public class TransaccionUseCase
    {
        /// <summary>
        /// Interfaz de conexion a BD
        /// </summary>
        private readonly ITransaccionesRepository _repository;
        /// <summary>
        /// Para mapear objetos
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public TransaccionUseCase(ITransaccionesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Metodos private
        /// <summary>
        /// Consulta transaccion
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Transaccion?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public async Task<TransaccionResponse> CrearTransaccionAsync(TransaccionRequest request)
        {
            // Validaciones
            if (request.ClienteId <= 0)
                throw new ArgumentException("ClienteId inválido");

            if (request.Monto <= 0)
                throw new ArgumentException("El monto debe ser mayor a cero");

            if (request.Tipo != "credito" && request.Tipo != "debito")
                throw new ArgumentException("Tipo inválido");

            var transaccion = _mapper.Map<Transaccion>(request);

            // Valores controlados por el sistema
            transaccion.Fecha = DateTime.UtcNow;
            transaccion.Estado = EstadoTransaccion.Pendiente.ToString();

            await _repository.CrearTransaccionAsync(transaccion);

            return _mapper.Map<TransaccionResponse>(transaccion);
        }

        /// <summary>
        /// Actualizar transaccion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> ActualizarEstadoAsync(int id, TransaccionRequestUpdate request)
        {
            var transaccion = await _repository.GetByIdAsync(id);

            if (transaccion == null)
                throw new Exception("Transacción no encontrada");

            if (transaccion.Estado != EstadoTransaccion.Pendiente.ToString())
                throw new Exception("Solo se pueden modificar transacciones pendientes");

            if (request.Estado != EstadoTransaccion.Procesada.ToString() &&
                request.Estado != EstadoTransaccion.Rechazada.ToString())
                throw new Exception("Estado inválido");

            transaccion.Estado = request.Estado;

            var response = await _repository.ActualizarEstadoAsync(id, transaccion);

            return response;
        }

        /// <summary>
        /// Obtener resumen de clientes
        /// </summary>
        /// <param name="clienteId"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<ResumentClienteResponse> ObtenerResumenClienteAsync(int clienteId)
        {
            if (clienteId <= 0)
                throw new ArgumentException("ClienteId inválido");

            // Obtener transacciones del cliente
            var transacciones = await _repository.ObtenerPorClienteIdAsync(clienteId);

            if (transacciones == null || !transacciones.Any())
            {
                return new ResumentClienteResponse
                {
                    SaldoActual = 0,
                    CantidadPendientes = 0,
                    CantidadProcesadas = 0,
                    CantidadRechazadas = 0,
                    UltimaTransaccionProcesada = null
                };
            }

           
            var procesadas = transacciones
                .Where(t => t.Estado.ToLower() == "procesada");

        
            var saldo = procesadas
                .Sum(t => t.Tipo.ToLower() == "credito" ? t.Monto : -t.Monto);

        
            var resumen = new ResumentClienteResponse
            {
                SaldoActual = saldo,

                CantidadPendientes = transacciones.Count(t => t.Estado.ToLower() == "pendiente"),
                CantidadProcesadas = transacciones.Count(t => t.Estado.ToLower() == "procesada"),
                CantidadRechazadas = transacciones.Count(t => t.Estado.ToLower() == "rechazada"),

                UltimaTransaccionProcesada = procesadas
                    .OrderByDescending(t => t.Fecha)
                    .Select(t => (DateTime?)t.Fecha)
                    .FirstOrDefault()
            };

            return resumen;
        }

      
        #endregion

    }
}
