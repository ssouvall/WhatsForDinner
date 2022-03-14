using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.IngredientListItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public IngredientListItem IngredientListItem { get; set; }
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
                var ingredientListItem = await _context.IngredientListItems.FindAsync(request.IngredientListItem.Id);

                _mapper.Map(request.IngredientListItem, ingredientListItem);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}