using PlayerController;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVC
{
    [RequireComponent(typeof(Image))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI healthText;

        private Image _healthImage;
        private PlayerBase _player;

        public void Construct(PlayerBase playerBase)
        {
            _player = playerBase;
            _healthImage = GetComponent<Image>();

            _player.OnHealthChange += UpdateHealthText;
            _player.OnPlayerDeath += HandlePlayerDeath;
        }

        private void UpdateHealthText()
        {
            healthText.text = $"Health: {_player.CurrentHealth}/{_player.MaxHealth}";
        }

        private void HandlePlayerDeath()
        {
            _healthImage.color = Color.red;
        }
    }
}