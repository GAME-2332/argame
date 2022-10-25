using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class SurfaceManager : MonoBehaviour {
    [NonSerialized] public ARPlaneManager PlaneManager;
    [NonSerialized] public ARPlane Surface;

    // Start is called before the first frame update
    void Start() {
        PlaneManager = GetComponent<ARPlaneManager>();
    }

    void Lock(ARPlane surface) {
        foreach (var plane in PlaneManager.trackables) {
            if (plane != surface) plane.gameObject.SetActive(false);
        }

        Surface = surface;
        PlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args) {
        foreach (var plane in args.added) {
            plane.gameObject.SetActive(false);
        }
    }

}
