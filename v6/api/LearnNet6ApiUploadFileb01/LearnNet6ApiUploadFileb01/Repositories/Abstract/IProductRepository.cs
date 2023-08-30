using LearnNet6ApiUploadFileb01.Models;

namespace LearnNet6ApiUploadFileb01.Repositories.Abstract
{
    public interface IProductRepository
    {
        bool Add(Product model);
    }
}
