using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Colaborator.Commands.DeleteCandidateCommand
{
    public class DeleteCandidateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public bool State { get; set; }
    }

    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Candidate> _repositoryAsync;
        private readonly IMapper _mapper;

        public DeleteCandidateCommandHandler(IMapper mapper, IRepositoryAsync<Candidate> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Guid>> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            if(request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);
        }

        public async Task<Response<Guid>> HandleProcess(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _repositoryAsync.GetByIdAsync(request.Id);

            if(candidate == null)
            {
                throw new Exception($"Candidate with id: {request.Id} doesn't exist");
            }
            else
            {
                candidate.State = request.State;

                await _repositoryAsync.UpdateAsync(candidate);

                return new Response<Guid>(candidate.Id);
            }
        }
    }
}
