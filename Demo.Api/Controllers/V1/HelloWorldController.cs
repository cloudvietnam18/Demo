using Demo.Api.Abstractions;
using Demo.AppServices.BizActions.Profiles;
using Demo.AppServices.Models.Profiles;
using Demo.AppServices.QueryServices;
using HBD.EfCore.BizAction;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Demo.Api.Controllers.V1
{
    public class HelloWorldController : BaseController
    {
        #region Methods

        [HttpGet]
        public async Task<ActionResult<ProfileBasicView>> Get([FromServices] IProfileQueryService repo)
        {
            string helloMessage = "Welcome to Training Courses";
            return this.Send(helloMessage);
        }

        // [HttpPost]
        // public async Task<ActionResult<ProfileBasicView>> Post([FromBody] ProfileModel model,
        //     [FromServices] IActionServiceAsync<ICreateProfileAction> action)
        // {
        //     var result = await action.RunBizActionAsync<ProfileBasicView>(model).ConfigureAwait(false);
        //     return action.Status.Send(result);
        // }
        //
        // [HttpPut("{id}")]
        // public async Task<ActionResult<ProfileBasicView>> Put(Guid id, [FromBody] ProfileModel model,
        //     [FromServices] IActionServiceAsync<IUpdateProfileAction> action)
        // {
        //     var result = await action.RunBizActionAsync<ProfileBasicView>(model).ConfigureAwait(false);
        //     return action.Status.Send(result);
        // }

        #endregion Methods
    }
}
