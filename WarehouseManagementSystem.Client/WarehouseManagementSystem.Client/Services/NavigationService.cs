using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseManagementSystem.Client.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Application _application;

        public NavigationService(Application application)
        {
            _application = application;
        }

        public async Task PushModalAsync(Page page)
        {
            await _application.Windows[0].Navigation.PushModalAsync(page);
        }

        public async Task PopModalAsync()
        {
            await _application.Windows[0].Navigation.PopModalAsync();
        }

        public async Task PushAsync(Page page)
        {
            await _application.Windows[0].Navigation.PushAsync(page);
        }

        public async Task PopAsync()
        {
            await _application.Windows[0].Navigation.PopAsync();
        }
    }
}
