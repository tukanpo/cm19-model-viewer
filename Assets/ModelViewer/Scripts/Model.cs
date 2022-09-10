using UnityEngine;

namespace ModelViewer
{
    public class Model : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        public void PlayAnimation(string stateName, int layer)
        {
            _animator.Play(stateName, layer);
        }
    }
}
