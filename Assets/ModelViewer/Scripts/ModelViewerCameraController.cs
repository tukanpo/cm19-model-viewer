using System.Collections;
using UnityEngine;

namespace ModelViewer
{
    public class ModelViewerCameraController : MonoBehaviour
    {
        [SerializeField] GameObject _camera;
        [SerializeField] GameObject _model;
        [SerializeField] float _rotateSpeed = 0.4f;
        [SerializeField] float _zoomSpeed = 1f;

        public void RotateModel(Vector2 delta)
        {
            var angle = new Vector3(delta.x * _rotateSpeed, delta.y * _rotateSpeed, 0);
            _model.transform.Rotate(Vector3.up, -angle.x);
        }

        public void ZoomCamera(Vector2 scrollDelta)
        {
            _camera.transform.position += _camera.transform.forward * scrollDelta.y * _zoomSpeed;
        }

        public void SetRotateY(float y)
        {
            _model.transform.rotation = Quaternion.Euler(0, y, 0);
        }

        Coroutine _runningCoroutine;

        public void Test()
        {
            if (_runningCoroutine != null)
            {
                StopCoroutine(_runningCoroutine);
                _runningCoroutine = null;
            }
            else
            {
                _runningCoroutine = StartCoroutine(Run());
            }
        }

        IEnumerator Run()
        {
            while (true)
            {
                _model.transform.Translate(Vector3.forward * 3f * Time.deltaTime);
                _camera.transform.position = new Vector3(
                    _model.transform.position.x,
                    _model.transform.position.y + 0.9f,
                    _model.transform.position.z + -11f);
                yield return null;
            }
        }
    }
}
