using Newtonsoft.Json;
using PergunteAqui.Domain.Common;
using System;

namespace PergunteAqui.Api.ViewModels
{
    public abstract class BaseViewModel : IIdProperty
    {
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}
