using AutoMapper;
using data = Solution.DO.Objects;

namespace Solution.API.Mapping
{
    //Implementamois el casteo de objetos del auto mapper para no tener referencias circulares
    public class MappingProfile:Profile
    {
        public MappingProfile() {

            //Reverse map hace que la referencia sea de ambos lados
            //Representa el casting del objeto a el similar
            //Desde DO hacia dataModels
            //Domain to Resource
            CreateMap<data.Focus, DataModels.Focus>().ReverseMap();

            CreateMap<data.GroupInvitation, DataModels.GroupInvitation>().ReverseMap();

            CreateMap<data.GroupRequest, DataModels.GroupRequest>().ReverseMap();

            CreateMap<data.Group, DataModels.Group>().ReverseMap();

        } 
    }
}
