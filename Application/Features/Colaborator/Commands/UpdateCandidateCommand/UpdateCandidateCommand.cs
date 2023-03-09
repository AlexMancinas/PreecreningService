﻿using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Colaborator.Commands.UpdateCandidateCommand
{
    public class UpdateCandidateCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Client { get; set; }
        //public ICollection<Email> Emails { get; set; }
        //public ICollection<Phone> Phones { get; set; }
        public string Recruiter { get; set; }
        //public ICollection<Certification> Certifications { get; set; }
        public string Location { get; set; }
        public string EducationLevel { get; set; }
        public string CurrentPosition { get; set; }
        public float SalaryExpectations { get; set; }
        public float CurrentSalaryGross { get; set; }
        //public ICollection<Skill> Skills { get; set; }
        public string Experience { get; set; }
        //public ICollection<Language> Languages { get; set; }
        //public ICollection<QuestionsAnswer> QuestionsAnswers { get; set; }
        public string Notes { get; set; }
        public string Img { get; set; }
        public string CV { get; set; }


    }

    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, Response<Guid>>
    {
        private readonly IRepositoryAsync<Candidate> _repositoryAsync;
        private readonly IMapper _mapper;

        public UpdateCandidateCommandHandler(IMapper mapper, IRepositoryAsync<Candidate> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public Task<Response<Guid>> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException();
            }
            return HandleProcess(request, cancellationToken);

        }
        public async Task<Response<Guid>> HandleProcess(UpdateCandidateCommand request, CancellationToken cancellationTocken)
        {
            var candidate = await _repositoryAsync.GetByIdAsync(request.Id);

            if (candidate == null)
            {
                throw new Exception($"Candidate with Id: {request.Id} not found");
            }

            else
            {
                candidate.FullName = request.FullName;
                candidate.Client = request.FullName;
                //candidate.Email = request.Email;
                //candidate.Phone = request.Phone;
                candidate.Recruiter = request.Recruiter;
                //candidate.Certification = request.Certification;
                candidate.Location = request.Location;
                candidate.EducationLevel = request.EducationLevel;
                candidate.CurrentPosition = request.CurrentPosition;
                candidate.SalaryExpectations = request.SalaryExpectations;
                candidate.CurrentSalaryGross = request.CurrentSalaryGross;
                //candidate.Skill = request.Skill;
                candidate.Experience = request.Experience;
                //candidate.Language = request.Language;
                //candidate.QuestionAnswer = request.QuestionAnswer;
                candidate.Notes = request.Notes;
                candidate.CV = request.CV;
                candidate.Img = request.Img;

                await _repositoryAsync.UpdateAsync(candidate);

                return new Response<Guid>(candidate.Id);
            }
        }
    }
}

