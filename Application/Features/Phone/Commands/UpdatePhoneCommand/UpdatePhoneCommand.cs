using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Features.Phone.Commands.UpdatePhoneCommand
{
    public class UpdatePhoneCommand : IRequest<Response<Domain.Entities.Phone>>
    {
        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string PhoneNumber { get; set; }
  
    }

    public class UpdatePhoneCommandHandler : IRequestHandler<UpdatePhoneCommand, Response<Domain.Entities.Phone>>
    {
        private readonly IRepositoryAsync<Domain.Entities.Phone> _repositoryAsync;

        public UpdatePhoneCommandHandler(IRepositoryAsync<Domain.Entities.Phone> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<Domain.Entities.Phone>> Handle(UpdatePhoneCommand request, CancellationToken cancellationToken)
        {
            var phone = await _repositoryAsync.GetByIdAsync(request.Id);
            if (phone == null)
            {
                throw new ApiExceptions($"Phone Not Found.");
            }
            else
            {
                phone.CandidateId = request.CandidateId;
                phone.PhoneNumber = request.PhoneNumber;
                await _repositoryAsync.UpdateAsync(phone);
                return new Response<Domain.Entities.Phone>(phone);
            }
        }
    }
}
