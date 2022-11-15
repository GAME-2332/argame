using System;
using XR;

namespace DefaultNamespace {
    public class SelectableInteraction : Interaction {
        public override void Interact() {
            MainCamera.Instance.SetSelected(this);
        }

        private void OnDestroy() {
            if (MainCamera.Instance.GetSelected() == this) MainCamera.Instance.ClearSelected();
        }
    }
}