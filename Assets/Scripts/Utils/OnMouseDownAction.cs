using System;
using UnityEngine;

namespace Utils
{
    public class OnMouseDownAction : MonoBehaviour
    {
        public event Action Callback;

        private void OnMouseDown()
        {
            Callback?.Invoke();
        }
    }
}
