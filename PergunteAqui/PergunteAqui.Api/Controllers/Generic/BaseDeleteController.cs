﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PergunteAqui.Api.Filters;
using PergunteAqui.Api.ViewModels;
using PergunteAqui.Domain.Common;
using PergunteAqui.Service.Generic;
using System;

namespace PergunteAqui.Api.Controllers
{
    public class BaseDeleteController<T> : BaseDeleteController<T, T, T>
        where T : BaseEntity
    {
        public BaseDeleteController(IBaseService<T> service) : base(service) { }
    }

    public class BaseDeleteController<T, R> : BaseDeleteController<T, R, T>
       where T : BaseEntity
       where R : BaseViewModel
    {
        public BaseDeleteController(IBaseService<T> service) : base(service) { }
    }

    [GetClaimsFilter]
    [EnableCors("AllowAllHeaders")]
    public class BaseDeleteController<T, R, A> : BaseController<T, R, A>
        where T : BaseEntity
        where R : IIdProperty
        where A : class
    {

        public BaseDeleteController(IBaseService<T> service) : base(service) { }
 
        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public Result Delete(Guid id) => _service.Delete(id);
    }
}
