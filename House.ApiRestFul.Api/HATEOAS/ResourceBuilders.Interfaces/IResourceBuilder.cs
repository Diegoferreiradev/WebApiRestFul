﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace House.ApiRestFul.Api.HATEOAS.ResourceBuilders.Interfaces
{
    public interface IResourceBuilder
    {
        void BuilderResource(object resource, HttpRequestMessage request);
    }
}
