using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Recipes
{
    public class Create
    {
        public class Command : IRequest
        {
            public Recipe Recipe { get; set; }
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
                await _recipeService.CreateRecipe(request.Recipe);
                return Unit.Value;
            }
        }
        
    }
}