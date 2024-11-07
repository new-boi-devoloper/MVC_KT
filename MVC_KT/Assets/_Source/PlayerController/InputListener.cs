using UnityEngine;

namespace PlayerController
{
    public class InputListener : MonoBehaviour
    {
        private PlayerBase _playerBase;

        private float _movePosition;

        private void Update()
        {
            float moveHorizontal = Input.GetAxisRaw("Horizontal");
            float moveVertical = Input.GetAxisRaw("Vertical");

            Vector2 moveDirection = new Vector2(moveHorizontal, moveVertical).normalized;

            if (moveDirection.magnitude > 0)
            {
                _playerBase.Move(moveDirection);
            }
        }

        public void Construct(PlayerBase playerBase)
        {
            _playerBase = playerBase;
        }
    }
}