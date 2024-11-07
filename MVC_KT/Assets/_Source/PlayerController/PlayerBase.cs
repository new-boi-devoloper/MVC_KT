using System;
using UnityEngine;

namespace PlayerController
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class PlayerBase : MonoBehaviour
    {
        public abstract float MaxHealth { get; protected set; }
        public abstract float CurrentHealth { get; protected set; }
        public abstract Rigidbody PlayerRb { get; protected set; }

        public event Action OnPlayerDeath;
        public event Action OnHealthChange;

        public abstract void ChangeHealth(float amount);
        public abstract void Move(Vector2 direction);

        protected void OnOnPlayerDeath()
        {
            OnPlayerDeath?.Invoke();
        }

        protected void OnOnHealthChange()
        {
            OnHealthChange?.Invoke();
        }
    }
}