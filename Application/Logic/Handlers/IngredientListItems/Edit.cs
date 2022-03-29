using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.IngredientListItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public IngredientListItem IngredientListItem { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IIngredientListItemService _ingredientListItemService;
            public Handler(IIngredientListItemService ingredientListItemService)
            {
                _ingredientListItemService = ingredientListItemService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var ingredientListItem = await _ingredientListItemService.GetIngredientListItemDetails(request.IngredientListItem.Id);
                await _ingredientListItemService.EditIngredientListItem(request.IngredientListItem.Id, ingredientListItem);
                return Unit.Value;
            }
        }
    }
}