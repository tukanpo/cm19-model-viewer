using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ModelViewer
{
    public class AnimationMenuView : MonoBehaviour
    {
        public class LayerInfo
        {
            public int Index { get; }

            public string Name { get; }

            public List<StateInfo> StateInfos { get; }

            public LayerInfo(int index, string name, List<StateInfo> stateInfos)
            {
                Index = index;
                Name = name;
                StateInfos = stateInfos;
            }
        }

        public class StateInfo
        {
            public string Name { get; }

            public StateInfo(string name)
            {
                Name = name;
            }
        }

        [SerializeField] Animator _animator;
        [SerializeField] GameObject _content;
        [SerializeField] AnimationLayerView _animationLayerViewPrefab;

        List<LayerInfo> _layerInfos;

        public Action<AnimationStateView> OnChanged { get; set; }

        void Start()
        {
#if UNITY_EDITOR
            
            // TODO: サブステート考慮されてない
            // https://light11.hatenadiary.com/entry/2020/02/07/192647
            
            _layerInfos = new List<LayerInfo>();
            var rac = _animator.runtimeAnimatorController;
            var ac = rac as UnityEditor.Animations.AnimatorController;

            for (var i = 0; i < ac.layers.Length; i++)
            {
                var layer = ac.layers[i];
                var sm = layer.stateMachine;
                var stateInfos = sm.states.Select(state => new StateInfo(state.state.name)).ToList();
                _layerInfos.Add(new LayerInfo(i, layer.name, stateInfos));
            }

            foreach (var x in _layerInfos)
            {
                var obj = Instantiate(_animationLayerViewPrefab, _content.transform);
                obj.ApplyParam(x, OnChanged);
            }
#endif
        }
    }
}
