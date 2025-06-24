﻿using MediatR;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest<ServiceResponse<UpdateProductViewModel>>
    {
     
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }

    }
}
