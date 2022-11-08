using UnityEngine;
using XR;

namespace DefaultNamespace {
    [RequireComponent(typeof(Rigidbody))]
    public class DummyInteraction : Interaction {
        private Rigidbody _rigidbody;

        private void Start() {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public override void Interact() {
            _rigidbody.AddForce(Vector3.up * .5f, ForceMode.Impulse);
        }
    }
}