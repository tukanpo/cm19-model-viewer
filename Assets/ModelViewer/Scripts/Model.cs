using UnityEngine;

namespace ModelViewer
{
    public class Model : MonoBehaviour
    {
        [SerializeField] Animator _animator;

        public Animator Animator => _animator;

        void Start()
        {
            if (_animator == null)
            {
                var animator = GetComponentInChildren<Animator>();
                _animator = animator;
            }
        }
        
        public void PlayAnimation(string stateName, int layer)
        {
            _animator.Play(stateName, layer);
        }
    }
}
