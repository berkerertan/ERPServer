using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.RecipeDetails.UpdateRecipeDetail;

public sealed record UpdateRecipeDetailCommand(Guid Id,Guid ProductId,decimal Quantity) : IRequest<Result<string>>;


