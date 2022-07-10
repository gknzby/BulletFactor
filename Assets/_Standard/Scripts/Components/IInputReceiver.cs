using UnityEngine;

namespace Gknzby.Kit.Components
{
    public interface IInputReceiver
    {
        void ClickHandler(ref Vector2 screenPos);
        void ReleaseHandler(ref Vector2 screenPos);
        void PositionUpdateHandler(ref Vector2 screenPos);
    }
}