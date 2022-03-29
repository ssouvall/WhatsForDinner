using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Logic.Handlers.Ingredients
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Ingredient Ingredient { get; set; }
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
                var ingredient = await _context.Ingredients.FindAsync(request.Ingredient.Id);

                _mapper.Map(request.Ingredient, ingredient);

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}