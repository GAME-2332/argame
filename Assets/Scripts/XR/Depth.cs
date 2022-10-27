using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace XR {
    [RequireComponent(typeof(AROcclusionManager))]
    public class Depth : MonoBehaviour {
        public Texture2D DepthTexture => _depthTexture;
        
        private AROcclusionManager _occlusionManager;
        private int _depthWidth;
        private int _depthHeight;
        private Texture2D _depthTexture;
        private short[] _depthBuffer;

        private void Start() {
            _occlusionManager = GetComponent<AROcclusionManager>();
        }

        public bool IsDepthSupported() {
            return _occlusionManager.descriptor?.environmentDepthImageSupported == Supported.Supported;
        }

        public float GetPointDepth(Vector2 uv) {
            int depthX = (int)(uv.x * (_depthWidth - 1));
            int depthY = (int)(uv.y * (_depthHeight - 1));
            
            return GetPixelDepth(depthX, depthY);
        }
        
        /// <summary>
        /// Gets the depth of the given pixel in meters.
        /// </summary>
        public float GetPixelDepth(int x, int y) {
            if (_depthBuffer == null || x < 0 || x >= _depthWidth || y < 0 || y >= _depthHeight) {
                return -1;
            }

            var depthIndex = (y * _depthWidth) + x;
            var rawDepth = _depthBuffer[depthIndex];
            return rawDepth * 0.0001f;
        }

        public bool UpdateDepthTexture() {
            if (!IsDepthSupported()) return false;
            if (_occlusionManager && _occlusionManager.TryAcquireEnvironmentDepthCpuImage(out XRCpuImage image)) {
                using (image) {
                    UpdateRawImage(ref _depthTexture, image);
                    _depthWidth = image.width;
                    _depthHeight = image.height;
                }

                var buf = _depthTexture.GetRawTextureData();
                if (_depthBuffer == null) _depthBuffer = new short[buf.Length];
                Buffer.BlockCopy(buf, 0, _depthBuffer, 0, buf.Length);
                return true;
            }

            return false;
        }

        private static void UpdateRawImage(ref Texture2D texture2D, XRCpuImage image) {
            if (texture2D == null || texture2D.width != image.width || texture2D.height != image.height || texture2D.format != image.format.AsTextureFormat()) {
                texture2D = new Texture2D(image.width, image.height, image.format.AsTextureFormat(), false);
            }
            
            var conversionParams = new XRCpuImage.ConversionParams(image, texture2D.format, XRCpuImage.Transformation.MirrorY);
            var raw = texture2D.GetRawTextureData<byte>();
            
            image.Convert(conversionParams, raw);
            texture2D.Apply();
        }
    }
}