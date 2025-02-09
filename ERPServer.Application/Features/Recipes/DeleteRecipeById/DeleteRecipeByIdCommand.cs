using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Recipes.DeleteRecipeById;

public sealed record DeleteRecipeByIdCommand(Guid Id) : IRequest<Result<string>>;

internal sealed class DeleteRecipeByIdCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork) : IRequestHandler<DeleteRecipeByIdCommand, Result<string>>
{
    public async Task<Result<string>> Handle(DeleteRecipeByIdCommand request, CancellationToken cancellationToken)
    {
        Recipe recipe = await recipeRepository.GetByExpressionAsync(p => p.Id == request.Id, cancellationToken);

        recipeRepository.Delete(recipe);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçete başarıyla silindi";
    }
}
