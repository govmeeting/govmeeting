using System;
using System.Collections.Generic;
using System.Text;

namespace GM.Application.AppCore.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
