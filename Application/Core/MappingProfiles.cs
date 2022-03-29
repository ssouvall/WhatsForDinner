using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Recipe, Recipe>();
            CreateMap<Ingredient, Ingredient>();
            CreateMap<IngredientListItem, IngredientListItem>();
            CreateMap<ShoppingList, ShoppingList>();
        }
        
    }
}