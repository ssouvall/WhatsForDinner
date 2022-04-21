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

namespace Application.Logic.Handlers.Ingredients
{
    public class List
    {
        public class Query : IRequest<List<Ingredient>> { }
        public class Handler : IRequestHandler<Query, List<Ingredient>>
        {
            private readonly IIngredientService _ingredientService;
            public Handler(IIngredientService ingredientService)
            {
                _ingredientService = ingredientService;
            }
            public async Task<List<Ingredient>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _ingredientService.QueryIngredients().ToListAsync();
            }
        }

    }
}