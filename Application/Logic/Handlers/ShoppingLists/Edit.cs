using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.ShoppingLists
{
    public class Edit
    {
        public class Command : IRequest
        {
            public ShoppingList ShoppingList { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var shoppingList = await _context.ShoppingLists.FindAsync(request.ShoppingList.Id);

                _mapper.Map(request.ShoppingList, shoppingList);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}