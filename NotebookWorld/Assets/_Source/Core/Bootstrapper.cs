using System;
using InputSystem;
using PlayerSystem;
using UnityEngine;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private InputListener inputListener;
        private PlayerMovement _playerMovement;
        private void Awake()
        {
            SetUpGame();
        }

        private void SetUpGame()
        {
            _playerMovement = new PlayerMovement(player.PlayerSpeed, player.PlayerRb, player.PlayerJumpForce);
            inputListener.Construct(player, _playerMovement);
            
        }
    }
}
