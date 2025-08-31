namespace LogisticERP.DTOs.Mappings;
using AutoMapper;
using LogisticERP.Domain;

public class MotoristaDTOMappingProfile : Profile
{
    public MotoristaDTOMappingProfile()
    {
        CreateMap<Motorista, MotoristaDTO>().ReverseMap();
        CreateMap<MotoristaDTO, Motorista>().ReverseMap();
    }

}
