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
    public class Details
    {
        public class Query : IRequest<Recipe>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, Recipe>
        {
            private readonly IRecipeService _recipeService;
            public Handler(IRecipeService recipeService)
            {
                _recipeService = recipeService;
            }

            public async Task<Recipe> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _recipeService.GetRecipeDetails(request.Id);
            }
        }
    }
}