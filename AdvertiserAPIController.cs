using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sabio.Models.Domain;
using Sabio.Models.Requests;
using Sabio.Services;
using Sabio.Web.Controllers;
using Sabio.Web.Models.Responses;

namespace Sabio.Web.Api.Controllers
{
    [Route("api/advertisers")]
    [ApiController]
    public class AdvertiserAPIController : BaseApiController
    {
        private IAdvertiserService _service = null;

        public AdvertiserAPIController(IAdvertiserService service,
            ILogger<AdvertiserAPIController> logger) : base(logger)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<ItemResponse<Advertiser>> GetAll()
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                List<Advertiser> list = _service.GetAll();

                if (list == null)
                {
                    code = 404;
                    response = new ErrorResponse("App Resourse not found.");
                }
                else
                {
                    response = new ItemsResponse<Advertiser> { Items = list };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
                {
                    base.Logger.LogError(ex.ToString());
                }
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ItemResponse<Advertiser>> Get(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                Advertiser advertiser = _service.Get(id);

                if (advertiser == null)
                {
                    code = 404;
                    response = new ErrorResponse("Application Resource not found.");
                }
                else
                {
                    response = new ItemResponse<Advertiser> { Item = advertiser };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                base.Logger.LogError(ex.ToString());
                response = new ErrorResponse($"Generic Error: {ex.Message}");
            }
            return StatusCode(code, response);
        }



        [HttpPost]
        public ActionResult<ItemResponse<int>> Create(AdvertiserAddRequest model)
        {
            ObjectResult result = null;

            try
            {

                int id = _service.Add(model);
                ItemResponse<int> response = new ItemResponse<int>() { Item = id };
                result = Created201(response);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.ToString());
                ErrorResponse response = new ErrorResponse(ex.Message);

                result = StatusCode(500, response);
            }
            return result;
        }


        [HttpPut("{id:int}")]
        public ActionResult<ItemResponse<int>> Update(AdvertiserUpdateRequest model)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Update(model);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Delete(id);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }

            return StatusCode(code, response);
        }



    }
}