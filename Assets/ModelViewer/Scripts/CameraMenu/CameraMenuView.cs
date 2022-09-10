using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModelViewer
{
    // TODO: ModelRotationView

    public class CameraMenuView : MonoBehaviour
    {
        [SerializeField] Button _frontButton;
        [SerializeField] Button _leftButton;
        [SerializeField] Button _rightButton;
        [SerializeField] Button _backButton;

        // TODO: Y軸角度調整＆確認用の Input Field + Slider?

        public Action OnRotationFrontButton { get; set; }
        public Action OnRotationLeftButton { get; set; }
        public Action OnRotationRightButton { get; set; }
        public Action OnRotationBackButton { get; set; }

        void Start()
        {
            _frontButton.onClick.AddListener(() => OnRotationFrontButton?.Invoke());
            _leftButton.onClick.AddListener(() => OnRotationLeftButton?.Invoke());
            _rightButton.onClick.AddListener(() => OnRotationRightButton?.Invoke());
            _backButton.onClick.AddListener(() => OnRotationBackButton?.Invoke());
        }
    }
}
