using AutoMapper;
using MediatR;
using ProductApp.Application.Dto;
using ProductApp.Application.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Queries.GetAllProducts
{
    public class GetAllProductsQuery:IRequest<List<ProductViewDto>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewDto>>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMapper _mapper;
            public GetAllProductsQueryHandler(IProductRepository productRepository ,IMapper mapper)
            {
                _productRepository = productRepository;
                _mapper = mapper;
                
            }
            public async Task<List<ProductViewDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _productRepository.GetAllAsync();
                return _mapper.Map<List<ProductViewDto>>(products);
            }
        }
    }
}
