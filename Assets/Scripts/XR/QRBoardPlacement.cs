using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace XR {
    [RequireComponent(typeof(ARTrackedImageManager))]
    public class QRBoardPlacement : MonoBehaviour {
        private ARTrackedImageManager _imageManager;

        private void OnEnable() {
            _imageManager = GetComponent<ARTrackedImageManager>();
            _imageManager.trackedImagesChanged += TrackedImagesChanged;
        }

        private void OnDisable() {
            _imageManager.trackedImagesChanged -= TrackedImagesChanged;
        }

        private void TrackedImagesChanged(ARTrackedImagesChangedEventArgs args) {
            foreach (ARTrackedImage image in args.added) {
                if (image.referenceImage.name == "Main") {
                    Board.SetFollowTarget(image.transform);
                    break;
                }
            }
            
            foreach (ARTrackedImage image in args.updated) {
                if (image.referenceImage.name == "Main") {
                    if (image.trackingState == TrackingState.None) Board.ClearFollowTarget();
                    else {
                        Board.SetActive(true);
                        Board.SetFollowTarget(image.transform);
                        break;
                    }
                }
            }
            
            foreach (ARTrackedImage image in args.removed) {
                if (image.referenceImage.name == "Main") {
                    Board.ClearFollowTarget();
                    break;
                }
            }
        }
        
    }
}
