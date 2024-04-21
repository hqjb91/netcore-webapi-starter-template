using Ardalis.Specification;
using Domain;

namespace Core.Domain.Specification.EAV;
public class EAVEntityByDescriptionSpecification : Specification<EAVEntity>
{
    public EAVEntityByDescriptionSpecification(string description)
    {
        Query.Where(x => x.Description.ToLower().Contains(description.ToLower()))
            .Include(x => x.EAVAttributes)
            .ThenInclude(x => x.EAVValues);
    }
}