using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem.Client.Services
{
    public interface INavigationService
    {
        Task PushModalAsync(Page page);
        Task PopModalAsync();
    }
}
