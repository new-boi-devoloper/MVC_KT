using PlayerController;
using UnityEngine;

namespace MVC
{
    public class PlayerModel : PlayerBase
    {
        [field: SerializeField] public float PlayerHealth { get; private set; }
        [field: SerializeField] public float PlayerSpeed { get; private set; }

        public override float MaxHealth { get; protected set; }
        public override float CurrentHealth { get; protected set; }
        public override Rigidbody PlayerRb { get; protected set; }

        private void Start()
        {
            MaxHealth = PlayerHealth;
            CurrentHealth = MaxHealth;

            PlayerRb = GetComponent<Rigidbody>();
        }

        public override void ChangeHealth(float amount)
        {
            var newHealth = CurrentHealth + amount;

            if (newHealth <= 0)
            {
                CurrentHealth = 0;
                OnOnPlayerDeath();
            }
            else
            {
                CurrentHealth = newHealth;
                OnOnHealthChange();
            }

            OnOnHealthChange();
        }

        public override void Move(Vector2 direction)
        {
            var moveDirection = new Vector3(direction.x, 0, direction.y);
            PlayerRb.AddForce(moveDirection * PlayerSpeed, ForceMode.Force);
        }
    }
}