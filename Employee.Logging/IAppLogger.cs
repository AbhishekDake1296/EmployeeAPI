using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Logging
{
    public interface IAppLogger
    {
        [MessageTemplateFormatMethod("messageTemplate")]
        void LogInformation(string messageTemplate, params object[] propertyValues);

        [MessageTemplateFormatMethod("messageTemplate")]
        void LogError(Exception ex, string messageTemplate, params object[] propertyValues);
    }
}
