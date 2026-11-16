using MGGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class TimedTransition : IStateTransition
    {
        private Timer _timer;

        public TimedTransition(Timer timer)
        {
            _timer = timer;
        }

        public bool ToTransition()
        {
            return _timer.TimeRemaining <= 0;
        }
    }
}
