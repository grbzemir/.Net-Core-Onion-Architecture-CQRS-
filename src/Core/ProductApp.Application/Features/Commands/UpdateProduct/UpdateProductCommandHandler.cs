using AutoMapper;
using MediatR;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ServiceResponse<UpdateProductViewModel>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public UpdateProductCommandHandler(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<UpdateProductViewModel>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            if (product == null)
            {
                return new ServiceResponse<UpdateProductViewModel>(null);
            }

            product.Name = request.Name;
            product.Value = request.Value;
            product.Quantity = request.Quantity;

            await _productRepository.UpdateAsync(product);

            var productDto = _mapper.Map<UpdateProductViewModel>(product);
            return new ServiceResponse<UpdateProductViewModel>(productDto);
        }
      }
     }
   

