using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.IngredientListItems
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IIngredientListItemService _ingredientListItemService;
            public Handler(IIngredientListItemService ingredientListItemService)
            {
                _ingredientListItemService = ingredientListItemService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _ingredientListItemService.DeleteIngredientListItem(request.Id);
                return Unit.Value;
            }
        }
    }
}