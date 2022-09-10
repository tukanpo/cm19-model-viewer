using UnityEngine;
using UnityEngine.EventSystems;

namespace ModelViewer
{
    public class ModelViewerScene : MonoBehaviour
    {
        [SerializeField] Model _model;
        [SerializeField] AnimationMenuView _animationMenuView;
        [SerializeField] CameraMenuView _cameraMenuView;
        [SerializeField] ViewInputReceiver _viewInputReceiver;
        [SerializeField] CameraController _cameraController;

        void Start()
        {
            _viewInputReceiver.OnDragEvent = x =>
            {
                if (x.button == PointerEventData.InputButton.Left)
                    _cameraController.RotateModel(x.delta);
            };

            _viewInputReceiver.OnScrollEvent = x =>
            {
                _cameraController.ZoomCamera(x.scrollDelta);
            };

            _cameraMenuView.OnRotationFrontButton = () => _cameraController.SetRotateY(180);
            _cameraMenuView.OnRotationLeftButton = () => _cameraController.SetRotateY(-90);
            _cameraMenuView.OnRotationRightButton = () => _cameraController.SetRotateY(90);
            _cameraMenuView.OnRotationBackButton = () => _cameraController.SetRotateY(0);
        }

        void OnEnable()
        {
            _animationMenuView.OnChanged += OnAnimationListViewChanged;
        }

        void OnDisable()
        {
            _animationMenuView.OnChanged -= OnAnimationListViewChanged;
        }

        void OnAnimationListViewChanged(AnimationStateView cell)
        {
            _model.PlayAnimation(cell.StateName, cell.Layer);
        }
    }
}
