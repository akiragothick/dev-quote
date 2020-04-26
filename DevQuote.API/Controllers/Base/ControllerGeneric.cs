using DevQuote.API.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevQuote.API.Controllers.Base
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerGeneric<T> : ControllerBase
    {
        public T entity;
        public ControllerGeneric()
        {
            entity = (T)Activator.CreateInstance(typeof(T), new object[] { });
        }

        protected Message ValidateDto(object dto, List<string> fields)
        {
            ModelState.Clear();

            Message message = new Message();

            TryValidateModel(dto);

            foreach (var field in fields)
            {
                ModelState.TryGetValue(field, out ModelStateEntry modelStateEntry);

                if (modelStateEntry != null && modelStateEntry.Errors.Count > 0)
                    message.Messages.AddRange(modelStateEntry.Errors.Select(x => x.ErrorMessage).ToList());
            }

            if (message.ExistsMessages())
                message.Error();

            return message;
        }
    }
}
