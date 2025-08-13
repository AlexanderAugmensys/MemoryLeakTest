using Microsoft.Maui.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryLeakTest
{
    public static class AppService
    {
        public static NavigationManager NavigationManager { get; } = new NavigationManager();
    }
}
