using AutoMapper;
using MediatR;
using ProductApp.Application.Features.Commands.UpdateProduct;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, ServiceResponse<bool>>
    {
        IProductRepository _productRepository;
        IMapper _mapper;
        public DeleteProductCommandHandler(IProductRepository productRepository , IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.DeleteAsync(request.Id);
            return new ServiceResponse<bool>(result);
        }
    }
}
