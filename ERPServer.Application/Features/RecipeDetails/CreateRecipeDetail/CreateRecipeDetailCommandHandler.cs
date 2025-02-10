using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.RecipeDetails.CreateRecipeDetail;

internal sealed class CreateRecipeDetailCommandHandler(
    IRecipeDetailRepository recipeDetailRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateRecipeDetailCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateRecipeDetailCommand request, CancellationToken cancellationToken)
    {
        RecipeDetail? recipeDetails = await recipeDetailRepository
            .GetByExpressionWithTrackingAsync(p =>
            p.RecipeId == request.RecipeId && p.ProductId == request.ProductId, cancellationToken);

        if (recipeDetails is not null)
        {
            recipeDetails.Quantity += request.Quantity;
        }
        else
        {
            recipeDetails = mapper.Map<RecipeDetail>(request);
            await recipeDetailRepository.AddAsync(recipeDetails, cancellationToken);
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Reçete ürün kaydı başarıyla tamamlandı";

    }
}



