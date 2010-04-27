using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HOAHome.Code.Rules
{
    public interface IRule
    {
        bool IsValid { get; }
        string[] ParticipatingLogicalFields { get; }
        string GetErrorMessage();
    }
}