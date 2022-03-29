using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Recipes
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IRecipeService _recipeService;
            public Handler(IRecipeService recipeService)
            {
                _recipeService = recipeService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _recipeService.DeleteRecipe(request.Id);
                return Unit.Value;
            }
        }
    }
}