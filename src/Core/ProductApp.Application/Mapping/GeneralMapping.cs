﻿using AutoMapper;
using ProductApp.Application.Dto;
using ProductApp.Application.Features.Commands.CreateProduct;
using ProductApp.Application.Features.Commands.DeleteProduct;
using ProductApp.Application.Features.Commands.UpdateProduct;
using ProductApp.Application.Features.Queries.GetProductById;
using ProductApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Product, ProductViewDto>();
            CreateMap<ProductViewDto, Product>();

            CreateMap<Product, CreateProductCommand>();
            CreateMap<CreateProductCommand, Product>();

            CreateMap<Product, GetProductByIdViewModel>();
            CreateMap<GetProductByIdViewModel, Product>();

            CreateMap<Product, UpdateProductViewModel>();
            CreateMap<UpdateProductViewModel, Product>();

            CreateMap<Product, UpdateProductCommand>();
            CreateMap<UpdateProductCommand, Product>();

            CreateMap<Product, DeleteProductCommand>();
            CreateMap<DeleteProductCommand, Product>();
        }
    }
}
