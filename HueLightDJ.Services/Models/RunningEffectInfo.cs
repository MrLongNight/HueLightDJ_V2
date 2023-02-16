using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HueLightDJ.Services.Models
{
    public class RunningEffectInfo
    {
					public CancellationTokenSource? CancellationTokenSource { get; set; }
					public required string Name { get; set; }
		  }
}
