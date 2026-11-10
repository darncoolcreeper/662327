using MGGameLibrary;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainQuest4_DragonDrop
{
    public class SimpleTargetable : ITargetable
    {
        public Vector2 TargetPosition { get; }

        Vector2 ITargetable.TargetPosition => throw new NotImplementedException();

        public SimpleTargetable(Vector2 pos) => TargetPosition = pos;
    }
}
