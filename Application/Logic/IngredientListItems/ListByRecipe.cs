using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Logic.IngredientListItems
{
    public class ListByRecipe
    {
        public class Query : IRequest<List<IngredientListItem>> 
        { 
            public Guid RecipeId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<IngredientListItem>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<IngredientListItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.IngredientListItems
                    .Where(ili => ili.RecipeId == request.RecipeId)
                    .ToListAsync();
            }
        }

    }
}