using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModelViewer
{
    public class AnimationStateView : MonoBehaviour
    {
        public class Param
        {
            public string StateName { get; }

            public int Layer { get; }

            public Param(string stateName, int layer)
            {
                StateName = stateName;
                Layer = layer;
            }
        }

        [SerializeField] Button _button;

        public string StateName { get; private set; }
        public int Layer { get; private set; }

        public Action<AnimationStateView> OnChanged { get; set; }

        public void Start()
        {
            _button.onClick.AddListener(OnClick);
        }

        public void ApplyParam(Param param)
        {
            StateName = param.StateName;
            Layer = param.Layer;

            _button.GetComponentInChildren<Text>().text = param.StateName;
        }

        void OnClick()
        {
            OnChanged?.Invoke(this);
        }
    }
}
