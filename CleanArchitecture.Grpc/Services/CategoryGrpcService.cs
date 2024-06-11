//using CleanArchitecture.Application.Services;
//using Google.Protobuf.WellKnownTypes;
//using Grpc.Core;

//namespace CleanArchitecture.Grpc.Services
//{
//    public class CategoryGrpcService : CategoryService.CategoryServiceBase
//    {
//        private readonly CategoryService _categoryService;

//        public CategoryGrpcService(CategoryService categoryService)
//        {
//            _categoryService = categoryService;
//        }

//        public override async Task<CategoryList> GetAll(Empty request, ServerCallContext context)
//        {
//            var categories = await _categoryService.GetAllCategoriesAsync();
//            var response = new CategoryList();
//            response.Categories.AddRange(categories.Select(c => new CategoryModel
//            {
//                Id = c.Id,
//                Name = c.Name
//            }));

//            return response;
//        }
//    }
//}
