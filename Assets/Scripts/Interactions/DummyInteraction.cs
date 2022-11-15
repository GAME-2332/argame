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
            Vector3 direction = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)) * Vector3.up;
            _rigidbody.AddForce(direction * 2, ForceMode.Impulse);
        }
    }
}