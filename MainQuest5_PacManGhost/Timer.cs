using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class Timer
    {
        private float _totalTime;

        public float TimeRemaining { get; private set; }

        public Timer(float time)
        {
            _totalTime = time;
            TimeRemaining = time;
        }

        public void Start()
        {
            TimeRemaining = _totalTime;
        }

        public void Update(float seconds)
        {
            if (TimeRemaining > 0)
            {
                TimeRemaining -= seconds;

                if (TimeRemaining < 0)
                {
                    TimeRemaining = 0;
                }
            }
        }
    }
}
