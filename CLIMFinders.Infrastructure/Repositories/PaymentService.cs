using AutoMapper;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Application.Interfaces;
using CLIMFinders.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace CLIMFinders.Infrastructure.Repositories
{
    public class PaymentService(IUnitOfWork unitOfWork, ILogger<PaymentService> logger, IMapper mapper, IUserService userService) : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly ILogger<PaymentService> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IUserService _userService = userService;

        public GenericResponse AddUpdatePayment(PaymentRequestDto requestDto)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Payments>();
                if (requestDto.Id == 0)
                {
                    var mapped = _mapper.Map<Payments>(requestDto);
                    var entity = repository.Insert(mapped);
                    entity.UserId = entity.AddedById = entity.ModifiedById = _userService.GetUserId();
                    entity.AddedOn = entity.ModifiedOn = DateTime.Now;
                    repository.Save();
                    GenericResponse genericResponse = new(entity.Id, entity.UserId, "Payment Successful", entity, true);
                    return genericResponse;

                }
                else
                {
                    var payment = repository.GetById(requestDto.Id);
                    var mapped = _mapper.Map(requestDto, payment);
                    mapped.UserId = mapped.ModifiedById = _userService.GetUserId();
                    mapped.ModifiedOn = DateTime.Now;
                    repository.Update(mapped);
                    repository.Save();
                    GenericResponse genericResponse = new(mapped.Id, mapped.UserId, "Payment Successfully updated", mapped, true);
                    return genericResponse;
                }
            }
            catch
            {
                throw;
            }
        }

    }
     
}