
using Service_Layer.Models;

namespace Service_Layer.IServices
{
    public interface ICategoryService
    {
        IEnumerable<CategoryServiceModel> GetAllCategories();
        CategoryServiceModel GetCategoryById(int id);
        void AddCategory(CategoryServiceModel category);
        void UpdateCategory(CategoryServiceModel category);
        void RemoveCategory(int id);
    }
}
