using ERPServer.Domain.Entities;
using ERPServer.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace ERPServer.Application.Features.Customers.GetAllCustomer
{
    public sealed record GetAllCustomerQuery():IRequest<Result<List<Customer>>>;
    internal sealed class GetAllCustomerQueryHandler(ICustomerRepository customerRepository) : IRequestHandler<GetAllCustomerQuery, Result<List<Customer>>>
    {
        public async Task<Result<List<Customer>>> Handle(GetAllCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customers = await customerRepository.GetAll().OrderBy(p=>p.Name).ToListAsync(cancellationToken);
            return customers;
        }
    }
}
