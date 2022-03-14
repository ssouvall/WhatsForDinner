using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Logic.Ingredients
{
    public class List
    {
        public class Query : IRequest<List<Ingredient>> { }
        public class Handler : IRequestHandler<Query, List<Ingredient>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Ingredient>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Ingredients.ToListAsync();
            }
        }

    }
}