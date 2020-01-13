using System;
using System.Collections.Generic;
using System.Text;
using Solid.Appenders.Contracts;
using Solid.Enumerations;
using Solid.Layouts.Contracts;

namespace Solid.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevel level, string message)
        {
            if (level >= ReportLevel)
            {
                Console.WriteLine(String.Format(Layout.Format, date, level, message));
                this.MessagesCount++;
            }
        }
    }
}
