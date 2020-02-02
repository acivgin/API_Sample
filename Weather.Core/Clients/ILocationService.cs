using System;
using System.Collections.Generic;
using System.Text;
using Weather.Core.Entities.Location;

namespace Weather.Core.Clients
{
    interface ILocationService
    {
        City Get();
    }
}
