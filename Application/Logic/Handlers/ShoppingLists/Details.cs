using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class Details
    {
        public class Query : IRequest<ShoppingList>
        {
            public Guid Id { get; set; }
        }
        
        public class Handler : IRequestHandler<Query, ShoppingList>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<ShoppingList> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ShoppingLists.FindAsync(request.Id); 
            }
        }
    }
}