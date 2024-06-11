//using CleanArchitecture.Application.Interfaces;
//using CleanArchitecture.Application.Services;
//using CleanArchitecture.Domain.Entities;
//using Google.Protobuf.WellKnownTypes;
//using Grpc.Core;

//namespace CleanArchitecture.Grpc.Services
//{
//    public class ProductGrpcService : ProductService.ProductServiceBase
//    {
//        private readonly IProductService _productService;

//        public ProductGrpcService(IProductService productService)
//        {
//            _productService = productService;
//        }

//        public override async Task<ProductList> GetAll(Empty request, ServerCallContext context)
//        {
//            var products = await _productService.GetAllProductsAsync();
//            var response = new ProductList();
//            response.Products.AddRange(products.Select(p => new ProductModel
//            {
//                Id = p.Id,
//                Name = p.Name,
//                Price = (double)p.Price,
//                CategoryId = p.CategoryId
//            }));

//            return response;
//        }
//    }
//}
