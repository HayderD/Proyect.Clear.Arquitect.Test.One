using AutoMapper;
using Proyect.Clear.Arquitect.Application.Requests;
using Proyect.Clear.Arquitect.Domain.Entity;
using Proyect.Clear.Arquitect.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Clear.Arquitect.Application.UseCases
{
    public class ProductUseCase
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        //private Arquitect.Infrastructure.Service.EfProductRepository efRepo;

        public ProductUseCase(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;   
        }

        //public ProductUseCase(Arquitect.Infrastructure.Service.EfProductRepository efRepo)
        //{
        //    this.efRepo = efRepo;
        //}

        /// <summary>
        /// Crea un producto
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> AddAsync(ProductRequest request)
        { 
            var existing = await _repository.GetByNameAsync(request.Name);
            if (existing != null) return "El nombre de producto ya existe.";

            var product = _mapper.Map<Product>(request);
            await _repository.AddAsync(product);

            return "Producto registrado.";
        }        

        /// <summary>
        /// Actualiza un producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> UpdateAsync(string id, ProductRequest request)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return "El id de producto a actualizar no existe.";

            _mapper.Map(request, existing);
            await _repository.UpdateAsync(existing);

            return "Producto actalizado.";
        }

        /// <summary>
        /// Buscar por id un producto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductResponse> GetByIdAsync(string id)
        {
            var products = await _repository.GetByIdAsync(id);
            if (products == null)
                return new ProductResponse();

            return _mapper.Map<ProductResponse>(products);
        }

        /// <summary>
        /// Lista todos los producto mayor o igual al precio ingresado
        /// </summary>
        /// <param name="price"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProductResponse>> ByPrecisAsync(double price)
        {
            var products = await _repository.GetPriceMinAsync(price);
            if (products == null)
                return Enumerable.Empty<ProductResponse>();

            return _mapper.Map< IEnumerable < ProductResponse >> (products);
        }

        /// <summary>
        /// Lista todos los productos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProductResponse>> GetAllAsync()
        {
            var products = await _repository.GetAsync();
            return _mapper.Map<IEnumerable<ProductResponse>>(products);
        }

        /// <summary>
        /// elimina un producto en especifico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<string> DeleteAsync(string id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return "El id de producto a eliminar no existe.";
            var result = await _repository.DeleteAsync(existing);
            return result.GetValueOrDefault()
                ? "Producto eliminado."
                : "No fue posible eliminar el producto.";
        }
    }
}
