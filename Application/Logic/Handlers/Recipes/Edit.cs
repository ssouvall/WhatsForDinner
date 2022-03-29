using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Recipes
{
    public class Edit
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
                var recipe = await _recipeService.GetRecipeDetails(request.Recipe.Id);
                await _recipeService.EditRecipe(request.Recipe.Id, recipe);
                return Unit.Value;
            }
        }
    }
}