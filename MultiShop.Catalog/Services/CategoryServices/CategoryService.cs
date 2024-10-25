﻿using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var dataBase = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = dataBase.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value); 
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == categoryId);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x=>true).ToListAsync();
            return (_mapper.Map<List<ResultCategoryDto>>(values));
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string categoryId)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>( values);

        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.ReplaceOneAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
