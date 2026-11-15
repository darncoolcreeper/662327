using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGGameLibrary
{
    public interface IState
    {
        public void OnEnter();
        public void OnExit();
        public void OnUpdate(float seconds);
    }
}
