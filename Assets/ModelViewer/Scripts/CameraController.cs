using UnityEngine;

namespace ModelViewer
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] GameObject _camera;
        [SerializeField] GameObject _model;
        [SerializeField] float _rotateSpeed = 0.4f;
        [SerializeField] float _zoomSpeed = 0.1f;
        [SerializeField] float _moveSpeed = 0.01f;

        public void RotateModel(Vector2 delta)
        {
            var angle = new Vector3(delta.x * _rotateSpeed, delta.y * _rotateSpeed, 0);
            _model.transform.Rotate(Vector3.up, -angle.x);
        }

        public void ZoomCamera(Vector2 delta)
        {
            _camera.transform.position += _camera.transform.forward * delta.y * _zoomSpeed;
        }

        public void MoveCamera(Vector2 delta)
        {
            _camera.transform.position += -1 * (Vector3)delta * _moveSpeed;
        }

        public void SetRotateY(float y)
        {
            _model.transform.rotation = Quaternion.Euler(0, y, 0);
        }
    }
}
