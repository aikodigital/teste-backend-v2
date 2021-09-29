using Application.Helpers;
using Domain;

namespace Application.Specifications
{
    public class EquipmentSpecification : BaseSpecification<Equipment>
    {
        public EquipmentSpecification()
        {
            AddInclude(x=>x.EquipmentModel);
        }
    }
}