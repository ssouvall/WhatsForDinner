using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Ingredients
{
    public class Details
    {
        public class Query : IRequest<Ingredient>
        {
            public int Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, Ingredient>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Ingredient> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Ingredients.FindAsync(request.Id); 
            }
        }
    }
}