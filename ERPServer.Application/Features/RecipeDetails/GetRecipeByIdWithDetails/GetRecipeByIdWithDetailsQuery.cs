using ERPServer.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.RecipeDetails.GetRecipeByIdWithDetails;

public sealed record GetRecipeByIdWithDetailsQuery(Guid RecipeId) : IRequest<Result<Recipe>>;

