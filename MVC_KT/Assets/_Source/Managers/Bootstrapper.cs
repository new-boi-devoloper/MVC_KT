using MVC;
using PlayerController;
using UnityEngine;

namespace Managers
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private PlayerView playerView;
        private PlayerBase _player;

        private MVC.PlayerController _playerController;

        private void Awake()
        {
            var playerInstance = Instantiate(playerPrefab, transform.position, transform.rotation);

            _player = playerInstance.GetComponent<PlayerBase>();
            _playerController = playerInstance.GetComponent<MVC.PlayerController>();

            inputListener.Construct(_player);
            _playerController.Construct(_player, playerView);
            playerView.Construct(_player);
        }
    }
}