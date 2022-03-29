using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.IngredientListItems
{
    public class CreateBulk
    {
        public class Command : IRequest
        {
            public List<IngredientListItem> IngredientListItems { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if(request.IngredientListItems.Count > 0)
                {
                    foreach(var item in request.IngredientListItems)
                    {
                        _context.IngredientListItems.Add(item);
                        await _context.SaveChangesAsync();
                    }
                }
                return Unit.Value;
            }
        }
        
    }
}