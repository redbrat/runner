using System;

namespace Source.Game.Input
{
    public interface IHorizontalInputController
    {
        event Action<int> HorizontalInput;
    }
}
