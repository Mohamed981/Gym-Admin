using Repositories;
using Mapper;
using Models;
using Models.DTO;
using Data.Repositories;
using Data.Infrastructure;

namespace Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private readonly ISubscriptionTypeMapper subTypeMapper;
        private readonly ISubscriptionTypeRepository subTypeRepository;
        private readonly IUnitOfWork unitOfWork;

        public SubscriptionTypeService(ISubscriptionTypeMapper subTypeMapper,ISubscriptionTypeRepository subTypeRepository, IUnitOfWork unitOfWork)
        {
            this.subTypeMapper = subTypeMapper;
            this.subTypeRepository = subTypeRepository;
            this.unitOfWork = unitOfWork;
        }

        public void CreateSubscriptionType(SubscriptionTypeDTO subTypeDTO)
        {
            SubscriptionType subType=subTypeMapper.SubscriptionTypeDtoToSubscriptionType(subTypeDTO);
            subTypeRepository.Add(subType);
        }

        public List<SubscriptionTypeDTO> GetSubscriptionTypes()
        {
            List<SubscriptionType> subscriptionTypes=subTypeRepository.GetAll().ToList();
            SubscriptionTypeDTO subscriptionTypeDto = new SubscriptionTypeDTO();
            List<SubscriptionTypeDTO> subscriptionTypesDto = new List<SubscriptionTypeDTO>();
            foreach (SubscriptionType subscriptionType in subscriptionTypes)
            {
                subscriptionTypeDto = subTypeMapper.SubscriptionTypeToSubscriptionTypeDto(subscriptionType);
                subscriptionTypesDto.Add(subscriptionTypeDto);
            }
            return subscriptionTypesDto;
        }

        public void Save()
        {
            unitOfWork.SaveChanges();
        }
    }
}