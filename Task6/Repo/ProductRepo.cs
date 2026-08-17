using Task6.Models;
using Task6.Repo.Interface;

namespace Task6.Repo
{
    public class ProductRepo:IProductRepo
    {
        private  List<Product> _products = new List<Product>();

        public Product Add(Product product)
        {
           _products.Add(product);
            return product;
        }

        public PagedResult<Product> GetAll(TaskFilterParams param)
        {
           IEnumerable<Product> products= _products;
            if(!string.IsNullOrEmpty(param.Search))
            {
                products = products.Where(p => p.Name.Contains(param.Search, StringComparison.OrdinalIgnoreCase));
            }
            if(param.IsCompleted.HasValue)
            {
                products = products.Where(p => p.IsCompleted == param.IsCompleted);
            }
            if(param.Price.HasValue)
            {
                products = products.Where(p => p.Price == param.Price);
            }
            var allowedsord=
                  new Dictionary<string, Func<Product, object>>
                  {
                      ["Name"] = p => p.Name,
                      ["Price"] = p => p.Price,
                      ["IsCompleted"] = p => p.IsCompleted
                  };
            if (allowedsord.TryGetValue(param.SortBy ?? "Price",out var keySelector))
            {
                products = param.Order == "desc" ? products.OrderByDescending(keySelector) : products.OrderBy(keySelector);
            }
            products = products.OrderByDescending(p => p.Name);
            products = products.Skip((param.Page - 1) * param.PageSize).Take(param.PageSize).ToList();

            return new PagedResult<Product>
            {
                Data = products,
                Page = param.Page,
                PageSize = param.PageSize,
                TotalCount = _products.Count()
            };
        }
    }
}
