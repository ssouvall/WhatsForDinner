using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.IngredientListItems
{
    public class Details
    {
        public class Query : IRequest<IngredientListItem>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, IngredientListItem>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<IngredientListItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.IngredientListItems.FindAsync(request.Id); 
            }
        }
    }
}