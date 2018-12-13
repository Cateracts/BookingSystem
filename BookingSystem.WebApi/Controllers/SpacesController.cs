using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using BookingSystem.WebApi.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace BookingSystem.WebApi.Controllers
{
    /// <summary>
    /// Controller for all things space related
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SpacesController : ControllerBase
    {
        private readonly IGetSpacesRequest getSpacesRequest;
        private readonly IGetSpacesResponseHandler getSpacesResponseHandler;

        public SpacesController(IGetSpacesRequest getSpacesRequest,
                                IGetSpacesResponseHandler getSpacesResponseHandler)
        {
            this.getSpacesRequest = getSpacesRequest;
            this.getSpacesResponseHandler = getSpacesResponseHandler;
        }
        
        [HttpGet]
        public ActionResult<Space> Get()
        {
            getSpacesRequest.Execute();

            return (getSpacesResponseHandler as GetSpacesPresenter).Result;
        }
    }
}
