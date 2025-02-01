using AutoMapper;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using GenericRepository;
using MediatR;
using TS.Result;

namespace ERPServer.Application.Features.Depots.CreateDepot;

internal sealed class CreateDepotCommandHandler(IDepotRepository depotRepository,IUnitOfWork unitOfWork,IMapper mapper) : IRequestHandler<CreateDepotCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateDepotCommand request, CancellationToken cancellationToken)
    {
        //bool isTaxNumberExist = await depotRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber, cancellationToken);

        //if (isTaxNumberExist)
        //{
        //    return Result<string>.Failure("Vergi numarası daha önce kaydedilmiş");
        //}

        Depot depot = mapper.Map<Depot>(request);

        await depotRepository.AddAsync(depot, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Depo kaydı başarıyla tamamlandı";
    }
}
