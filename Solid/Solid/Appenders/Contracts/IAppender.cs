using System;
using System.Collections.Generic;
using System.Text;
using Solid.Enumerations;
using Solid.Layouts.Contracts;

namespace Solid.Appenders.Contracts
{
    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string date, ReportLevel level, string message);

        ReportLevel ReportLevel { get; set; }
    }
}
