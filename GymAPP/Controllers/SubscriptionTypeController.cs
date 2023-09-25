using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Services;

namespace GymAPP.Controllers
{
    [Route("api/SubscriptionTypes")]
    [ApiController]
    public class SubscriptionTypeController : ControllerBase
    {
        private readonly ISubscriptionTypeService subTypeService;

        public SubscriptionTypeController(ISubscriptionTypeService subTypeService)
        {
            this.subTypeService = subTypeService;
        }

        [HttpGet]
        public ActionResult GetSubscriptionTypes()
        {
            List<SubscriptionTypeDTO> subscriptionTypesDto = subTypeService.GetSubscriptionTypes();

            return Ok(subscriptionTypesDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult AddSubscriptionType([FromBody]SubscriptionTypeDTO subTypeDTO)
        {
            subTypeService.CreateSubscriptionType(subTypeDTO);
            subTypeService.Save();

            return Ok();
        }
    }
}
