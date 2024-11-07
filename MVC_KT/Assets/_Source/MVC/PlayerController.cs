using PlayerController;
using UnityEngine;
using Utils;

namespace MVC
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMaskEnemy;
        [SerializeField] private LayerMask layerMaskHealer;
        private PlayerBase _playerModel;
        private PlayerView _playerView;

        private void OnCollisionEnter(Collision other)
        {
            if (LayerChecker.ContainsLayer(layerMaskEnemy, other.gameObject)) _playerModel.ChangeHealth(-10);

            if (LayerChecker.ContainsLayer(layerMaskHealer, other.gameObject)) _playerModel.ChangeHealth(10);
        }

        public void Construct(PlayerBase model, PlayerView view)
        {
            _playerModel = model;
            _playerView = view;
        }
    }
}