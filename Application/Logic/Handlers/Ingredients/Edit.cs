using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Ingredients
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Ingredient Ingredient { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IIngredientService _ingredientService;
            public Handler(IIngredientService ingredientService)
            {
                _ingredientService = ingredientService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var ingredient = await _ingredientService.GetIngredientDetails(request.Ingredient.Id);
                await _ingredientService.EditIngredient(request.Ingredient.Id, ingredient);
                return Unit.Value;
            }
        }
    }
}