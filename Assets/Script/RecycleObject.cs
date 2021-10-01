using System;
using UnityEngine;

namespace Script
{
    public class RecycleObject : MonoBehaviour
    {
        public bool isActivated = false;

        public Action<RecycleObject> destroyed;
        public Action<RecycleObject> outOfScreen;
        private Vector3 _targetPosition;

        public void Activate(Vector3 position)
        {
            isActivated = true;
            transform.position = position;
        }

        public void Activate(Vector3 startPosition, Vector3 targetPosition)
        {
            var transform1 = transform; // rider refactoring
            transform1.position = startPosition;
            this._targetPosition = targetPosition;
            var dir = (targetPosition - startPosition).normalized;
            transform.rotation = Quaternion.LookRotation(transform1.forward, dir);
            isActivated = true;
        }
    }
}