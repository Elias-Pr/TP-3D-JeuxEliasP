using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameLoopEtHierarchie.Components {
    [Serializable]
    public class AxisEvent : UnityEvent<float> {}

    public class BasicInput : MonoBehaviour {

        public AxisEvent MouseX;
        public AxisEvent MouseY;
        public AxisEvent Horizontal;
        public AxisEvent Vertical;
        public UnityEvent LeftClickDown;
        public UnityEvent RightClickDown;
    
        private void Update() {
            MouseX.Invoke(Input.GetAxis("Mouse X"));
            MouseY.Invoke(Input.GetAxis("Mouse Y"));
            Horizontal.Invoke(Input.GetAxis("Horizontal"));
            Vertical.Invoke(Input.GetAxis("Vertical"));
            if (Input.GetButtonDown("Fire1")) {
                LeftClickDown.Invoke();
            }
            if (Input.GetButtonDown("Fire2")) {
                RightClickDown.Invoke();
            }
        }

    }
}