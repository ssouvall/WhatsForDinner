using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Contracts;
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
            private readonly IIngredientService _ingredientService;
            public Handler(IIngredientService ingredientService)
            {
                _ingredientService = ingredientService;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await _ingredientService.DeleteIngredient(request.Id);
                return Unit.Value;
            }
        }
    }
}