using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Logic.Services
{
    public class ShoppingListItemService : IShoppingListItemService
    {
        private readonly IBaseRepositoryService<ShoppingListItem> _baseRepositoryService;
        private readonly DataContext _context;
        private readonly IMapper _mapper;


        public ShoppingListItemService(IBaseRepositoryService<ShoppingListItem> baseRepositoryService, DataContext context, IMapper mapper){
            _baseRepositoryService = baseRepositoryService;
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateBulk(List<ShoppingListItem> shoppingListItems)
        {
            if(shoppingListItems.Count > 0)
            {
                foreach(var item in shoppingListItems)
                {
                    await _baseRepositoryService.Create(item);
                }
            }
        }

        public async Task CreateShoppingListItem(ShoppingListItem shoppingListItem)
        {
            await _baseRepositoryService.Create(shoppingListItem);
        }

        public async Task DeleteShoppingListItem(Guid id)
        {
            await _baseRepositoryService.Delete(id);
        }

        public async Task EditShoppingListItem(ShoppingListItem editedItem, ShoppingListItem shoppingListItem)
        {
            await _baseRepositoryService.Edit(editedItem, shoppingListItem);
        }

        public async Task<ShoppingListItem> GetShoppingListItemDetails(Guid id)
        {
            return await _baseRepositoryService.GetDetails(id);
        }

        public IQueryable<ShoppingListItem> QueryShoppingListItems()
        {
            return _baseRepositoryService.GetAll();
        }

        public async Task<List<ShoppingListItem>> GetIngredientsByShoppingList(Guid shoppingListId)
        {
            return await _baseRepositoryService.GetAll()
                .Where(sli => sli.ShoppingListId == shoppingListId)
                .ToListAsync();
        }
    }
}