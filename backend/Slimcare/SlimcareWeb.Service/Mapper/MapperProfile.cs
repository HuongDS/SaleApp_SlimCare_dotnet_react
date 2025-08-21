namespace SlimcareWeb.Service.Mapper
{
    using AutoMapper;
    using SlimcareWeb.DataAccess.Entities;
    using SlimcareWeb.Service.Dtos;
    using SlimcareWeb.Service.Dtos.Category;
    using SlimcareWeb.Service.Dtos.Order;
    using SlimcareWeb.Service.Dtos.OrderDetails;
    using SlimcareWeb.Service.Dtos.Product;
    using SlimcareWeb.Service.Dtos.Review;
    using SlimcareWeb.Service.Dtos.User;
    using SlimcareWeb.Service.Services;

    /// <summary>
    /// Defines the <see cref="MapperProfile" />
    /// </summary>
    public class MapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MapperProfile"/> class.
        /// </summary>
        public MapperProfile()
        {
            // Address
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, AddressViewDto>();
            CreateMap<UpdateAddressDto, Address>();

            // Category
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<Category, CategoryViewDto>();
            CreateMap<UpdateCategoryDto, Category>();

            // OrderDetails
            CreateMap<CreateOrderDetailsDto, OrderDetails>();

            // Order
            CreateMap<CreateOrderDto, Order>();
            CreateMap<Order, OrderViewDto>();
            CreateMap<UpdateOrderDto, Order>();

            // Product
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, ProductViewDto>();
            CreateMap<UpdateProductDto, Product>();

            // Review
            CreateMap<CreateReviewDto, Review>();
            CreateMap<Review, ReviewViewDto>();
            CreateMap<ReviewUpdateDto, Review>();

            // User
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<UserLoginDTO, User>();
            CreateMap<User, ResponseUserDto>();
        }
    }
}
