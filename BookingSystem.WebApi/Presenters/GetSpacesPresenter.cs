using BookingSystem.Core.Entities;
using BookingSystem.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace BookingSystem.WebApi.Presenters
{
    public class GetSpacesPresenter : IGetSpacesResponseHandler
    {
        public IList<Space> Spaces { get; set; }

        public JsonResult Result { get; set; }

        public void Success()
        {
            Result = new JsonResult(Spaces);
            Result.StatusCode = (int)HttpStatusCode.OK;
        }

        public void Fail(string message)
        {
            Result = new JsonResult(message);
            Result.StatusCode = (int)HttpStatusCode.BadRequest;
        }

        public void Error(Exception e)
        {
            Result = new JsonResult(e.Message);
            Result.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
