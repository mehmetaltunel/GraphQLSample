namespace GraphQL.Business.GraphQL.ResponseModels
{

    public class CategoryQueryResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [UseSorting]
        [UseFiltering]
        public IList<ProductQueryResponseModel> Products { get; set; }
    }
}
