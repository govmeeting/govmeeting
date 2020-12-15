using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
