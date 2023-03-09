using Application.Features.Certification.Commands.CreateCertificationCommand;
using Application.Features.Colaborator.Commands.CreateCandidateCommand;
using Application.Features.Email.Commands.CreateEmailCommnad;
using Application.Features.Language.Commands.CreateLanguageCommand;
using Application.Features.Phone.Commands.CreatePhoneCommand;
using Application.Features.QuestionsAnswer.Commands.CreateQuestionsAnswerCommand;
using Application.Features.Skill.Commands.CreateSkillCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            //#region DTOs
            //CreateMap<Candidate, Candidate>();
            //#endregion

            #region Commands
            CreateMap<CreateCandidateCommand, Candidate>();

            CreateMap<CreateEmailCommand, Email>();

            CreateMap<CreateCertificationCommand, Certification>();

            CreateMap<CreateLanguageCommand, Language>();

            CreateMap<CreatePhoneCommand, Phone>();

            CreateMap<CreateQuestionsAnswerCommand, QuestionsAnswer>();

            CreateMap<CreateSkillCommand, Skill>();
            #endregion
        }
    }
}
