using System;
using Microsoft.Extensions.Configuration;

using Persons.BL;
using Awards.BL;

namespace PersonsAndAwardsMVC
{
    public interface IMySingletonService
    {
        IPersonBL PersonBL { get; }
        IAwardBL AwardBL { get; }
    }
}
