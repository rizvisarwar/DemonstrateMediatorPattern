using System;
using System.Collections.Generic;
using System.Text;

namespace DemonstrateMediatorPattern.BusinessLogic.Features.Shared
{
    public sealed class ErrorDetailsResponse
    {
        public int? Code { get; set; }

        public Guid CorrelationId { get; set; }

        public List<string> Messages { get; set; }

        public string InnerMessage { get; set; }
    }
}
