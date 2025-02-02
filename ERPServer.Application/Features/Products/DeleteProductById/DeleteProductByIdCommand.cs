using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Products.DeleteProductById;

public sealed record DeleteProductByIdCommand(Guid Id) : IRequest<Result<string>>;

