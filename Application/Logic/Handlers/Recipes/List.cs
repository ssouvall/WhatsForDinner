using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Logic.Handlers.Recipes
{
    public class List
    {
        public class Query : IRequest<List<Recipe>> { }
        public class Handler : IRequestHandler<Query, List<Recipe>>
        {
            private readonly IRecipeService _recipeService;
            public Handler(IRecipeService recipeService)
            {
                _recipeService = recipeService;
            }

            public async Task<List<Recipe>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _recipeService.ListRecipes();
            }
        }

    }
}