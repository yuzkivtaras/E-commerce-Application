using AutoMapper;
using DataAccessLayer.Entities;
using DataAccessLayer.IRepository;
using Service_Layer.IServices;
using Service_Layer.Models;

namespace Service_Layer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryServiceModel> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            return _mapper.Map<IEnumerable<CategoryServiceModel>>(categories);
        }

        public CategoryServiceModel GetCategoryById(int id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryServiceModel>(category);
        }

        public void AddCategory(CategoryServiceModel categoryServiceModel)
        {
            var category = _mapper.Map<Category>(categoryServiceModel);
            _categoryRepository.Add(category);
        }

        public void UpdateCategory(CategoryServiceModel categoryServiceModel)
        {
            var category = _mapper.Map<Category>(categoryServiceModel);
            _categoryRepository.Update(category);
        }

        public void RemoveCategory(int id)
        {
            var category = _categoryRepository.GetById(id);
            _categoryRepository.Remove(category);
        }
    }
}
