using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp.Interfaces
{
    interface IObserver
    {
        void OnEvent(string eventType);
    }
}
