using MGGameLibrary;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest5_PacManGhost
{
    public class KeyReleaseTransition : IStateTransition
    {
        private bool _oldKeyState;
        public Keys Key { get; private set; }

        public KeyReleaseTransition(Keys key)
        {
            Key = key;
            _oldKeyState = Keyboard.GetState().IsKeyDown(Key);

        }

        public bool ToTransition()
        {
            if (_oldKeyState && Keyboard.GetState().IsKeyDown(Key))
            {
                _oldKeyState = true;
                return true;
            }
            _oldKeyState = Keyboard.GetState().IsKeyDown(Key);
            return false;
        }
    }
}
