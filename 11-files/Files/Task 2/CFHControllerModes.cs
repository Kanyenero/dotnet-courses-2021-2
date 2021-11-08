using System;
using System.Collections.Generic;
using System.Text;

namespace Task_2
{
    public partial class CFHController
    {
        public enum CFHControllerMode
        {
            Observation = 0,    // Режим наблюдений
            Rollback = 1        // Режим отката изменений
        }
    }
}
