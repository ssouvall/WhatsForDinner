using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Ingredients
{
    public class Details
    {
        public class Query : IRequest<Ingredient>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, Ingredient>
        {
            private readonly IIngredientService _ingredientService;
            public Handler(IIngredientService ingredientService)
            {
                _ingredientService = ingredientService;
            }

            public async Task<Ingredient> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _ingredientService.GetIngredientDetails(request.Id);
            }
        }
    }
}