using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Ingredients
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
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
                var ingredient = await _context.Ingredients.FindAsync(request.Id);
                _context.Remove(ingredient);
                await _context.SaveChangesAsync();
                return Unit.Value;
            }
        }
    }
}