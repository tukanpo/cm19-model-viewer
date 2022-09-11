using System;
using UnityEngine;
using UnityEngine.UI;

namespace ModelViewer
{
    public class AnimationLayerView : MonoBehaviour
    {
        [SerializeField] Text _headerLabel;
        [SerializeField] GameObject _content;
        [SerializeField] AnimationStateView _contentPrefab;

        public void ApplyParam(AnimationMenuView.LayerInfo layerInfo, Action<AnimationStateView> onChanged)
        {
            _headerLabel.text = layerInfo.Name;

            foreach (var x in layerInfo.StateInfos)
            {
                var obj = Instantiate(_contentPrefab, _content.transform);
                obj.ApplyParam(new AnimationStateView.Param(x.FullPath, layerInfo.Index));
                obj.OnChanged = onChanged;
            }
        }
    }
}
