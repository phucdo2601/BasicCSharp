using LearnBasicGenericUnitOfWorkb01.Dtos.Request;
using LearnBasicGenericUnitOfWorkb01.Models;
using LearnBasicGenericUnitOfWorkb01.Models.Entites;
using LearnBasicGenericUnitOfWorkb01.UnitOfWorks;
using System.Net.Mail;

namespace LearnBasicGenericUnitOfWorkb01.Services.Categories
{
    public class CategoryService : ICategoryService 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DatabaseContext _context;

        public CategoryService(IUnitOfWork unitOfWork, DatabaseContext context)
        {
            _unitOfWork= unitOfWork;
            _context = context;
        }

        public int CreateCategory(CategoryRequestModel categoryRequest)
        {
            /**
             * using transaction in EntityFramework for add new or update record
             */
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var categoryName = _unitOfWork.CategoryRepository.FindByCondition(e => e.CategoryName.Equals(categoryRequest.CategoryName)).Select(e => e.CategoryName).FirstOrDefault();
                    if (categoryName != null)
                    {
                        throw new Exception($"Category Name '{categoryName}' already exists");
                    }

                    Category category = new Category()
                    {
                        CategoryName = categoryRequest.CategoryName,
                        Description = categoryRequest.Description,
                        DateOfCreate = DateTime.Now,
                    };

                    _unitOfWork.CategoryRepository.Add(category);
                    int created = _unitOfWork.Save();
                    transaction.Commit();
                    return created;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
                return 0;
            }     
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                List<Category> categories = _unitOfWork.CategoryRepository.GetAll().ToList();
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _unitOfWork.Dispose();
            }

           
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                var category = _unitOfWork.CategoryRepository.FindByCondition(e => e.CategoryId.Equals(id)).FirstOrDefault();
                return category;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            finally
            {
                _unitOfWork.Dispose();
            }
            
        }

        public int UpdateCategory(int id, CategoryRequestModel categoryRequest)
        {
            /**
            * using transaction in EntityFramework for add new or update record
            */
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    int update = -1;

                    var cateById = _unitOfWork.CategoryRepository.FindByCondition(e => e.CategoryId.Equals(id)).FirstOrDefault();

                    if (cateById != null)
                    {
                        var categoryName = _unitOfWork.CategoryRepository.FindByCondition(e => !e.CategoryId.Equals(id) && e.CategoryName.Equals(categoryRequest.CategoryName)).Select(e => e.CategoryName).FirstOrDefault();
                        if (categoryName != null)
                        {
                            throw new Exception($"Category Name '{categoryName}' already exists");
                        }

                        cateById.CategoryName = categoryRequest.CategoryName;
                        cateById.Description = categoryRequest.Description;
                        cateById.DateOfCreate = DateTime.Now;

                        _unitOfWork.CategoryRepository.Update(cateById);
                        update = _unitOfWork.Save();
                        transaction.Commit();

                    }
                    return update;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
                finally
                {
                    _unitOfWork.Dispose();
                }
            }
        }
        
    }
}
