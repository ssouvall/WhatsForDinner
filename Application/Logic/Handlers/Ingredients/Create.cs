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
    public class Create
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
                await _ingredientService.CreateIngredient(request.Ingredient);
                return Unit.Value;
            }
        }
        
    }
}