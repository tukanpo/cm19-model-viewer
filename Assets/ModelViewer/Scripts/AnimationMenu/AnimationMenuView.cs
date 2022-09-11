using System;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace ModelViewer
{
    public class AnimationMenuView : MonoBehaviour
    {
        public class LayerInfo
        {
            public AnimatorControllerLayer Layer { get; }
            
            public int Index { get; }

            public string Name { get; }

            public List<StateInfo> StateInfos { get; }

            public LayerInfo(AnimatorControllerLayer layer, int index, string name, List<StateInfo> stateInfos)
            {
                Layer = layer;
                Index = index;
                Name = name;
                StateInfos = stateInfos;
            }
        }

        public class StateInfo
        {
            AnimatorState State { get; }

            public string FullPath { get; }
            
            public StateInfo(AnimatorState state, string fullPath)
            {
                State = state;
                FullPath = fullPath;
            }
        }

        [SerializeField] GameObject _content;
        [SerializeField] AnimationLayerView _animationLayerViewPrefab;

        Animator _animator;
        List<LayerInfo> _layerInfos;

        public Action<AnimationStateView> OnChanged { get; set; }

        public void ApplyParam(Animator animator)
        {
            _animator = animator;
            _layerInfos = new List<LayerInfo>();

            GetAllAnimationStatesOnlyEditor(_layerInfos);

            foreach (var x in _layerInfos)
            {
                var obj = Instantiate(_animationLayerViewPrefab, _content.transform);
                obj.ApplyParam(x, OnChanged);
            }
        }

        void GetAllAnimationStatesOnlyEditor(List<LayerInfo> resultLayerInfos)
        {
#if UNITY_EDITOR
            var rac = _animator.runtimeAnimatorController;
            var ac = rac as AnimatorController;

            for (var i = 0; i < ac.layers.Length; i++)
            {
                var layer = ac.layers[i];
                var stateInfos = new List<StateInfo>();
                GetAllStates(layer.stateMachine, null, stateInfos);
                
                resultLayerInfos.Add(new LayerInfo(layer, i, layer.name, stateInfos));
            }
#endif
        }

        void GetAllStates(AnimatorStateMachine stateMachine, string parentPath, List<StateInfo> resultStateInfos)
        {
            if (!string.IsNullOrEmpty(parentPath))
            {
                parentPath += ".";
            }
 
            foreach (var state in stateMachine.states)
            {
                var stateFullPath = $"{parentPath}{state.state.name}";
                resultStateInfos.Add(new StateInfo(state.state, stateFullPath));
            }

            foreach (var subStateMachine in stateMachine.stateMachines)
            {
                GetAllStates(subStateMachine.stateMachine, subStateMachine.stateMachine.name, resultStateInfos);
            }
        }
    }
}
