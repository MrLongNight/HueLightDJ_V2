using HueLightDJ.Services;
using HueLightDJ.Services.Interfaces;
using HueLightDJ.Services.Interfaces.Models;
using HueLightDJ.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HueLightDJ.Web.Services
{
  public class HubService : IHubService
  {
    private IHubContext<PreviewHub> _hub;

    public HubService(IHubContext<PreviewHub> hub)
    {
      _hub = hub;
    }

    public event EventHandler<string?>? LogMsgEvent;
    public event EventHandler? StatusChangedEvent;
    public event EventHandler<IEnumerable<PreviewModel>>? PreviewEvent;

    public Task SendAsync(string method, params object?[] arg1)
    {
      if (arg1.Length > 1)
      {
        return _hub.Clients.All.SendAsync(method, arg1[0], arg1[1]);

      }
      else
      {
        return _hub.Clients.All.SendAsync(method, arg1[0]);
      }
    }

    public Task SendPreview(IEnumerable<PreviewModel> list)
    {
      return SendAsync("preview", list);
    }

    public Task StatusChanged()
    {
      return Task.CompletedTask;
    }
  }
}
