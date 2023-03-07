using Application.DTOs;
using Application.Features.Colaborator.Commands.CreateCandidateCommand;
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
            CreateMap<CreateCandidateCommand, Domain.Entities.Candidate>();
            #endregion
        }
    }
}
