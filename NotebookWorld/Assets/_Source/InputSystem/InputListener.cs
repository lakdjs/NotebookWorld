using System;
using PlayerSystem;
using UnityEngine;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";
        private const string Vertical = "Vertical";
        
        private Player _player;
        private PlayerMovement _playerMovement;
        
        private Vector2 _moveDir = new Vector2();

        private bool _isFaceRight = true;

        private bool _jumpControl = false;
        private int _jumpIteration = 0;
        private int _jumpValueIteration = 60;
        public void Construct(Player player, PlayerMovement playerMovement)
        {
            _player = player;
            _playerMovement = playerMovement;
        }
        
        private void Update()
        {
            //Flip();
            ReadJump();
            Reflect();
        }

        private void Reflect()
        {
            if((_moveDir.x > 0 && !_isFaceRight) || (_moveDir.x < 0 && _isFaceRight))
            {
                _player.transform.localScale *= new Vector2(-1, 1);
                _isFaceRight = !_isFaceRight;
            }
        }
        private void Flip()
        {
            _player.PlayerSpriteRenderer.flipX = _moveDir.x < 0;
        }

        private void FixedUpdate()
        {
            ReadMove();
        }

        
        private void ReadMove()
        {
            float horizontal = Input.GetAxis(Horizontal);
            float vertical = Input.GetAxis(Vertical);
            _moveDir = new Vector2(horizontal, vertical);
            _player.PlayerAnimator.SetFloat("MoveX", Math.Abs(_moveDir.x));
            _playerMovement.Move(_moveDir);
            if (vertical < 0)
            {
                Physics2D.IgnoreLayerCollision(7,8,true);
                Invoke("IgnoreLayerOff", 0.5f);
            }
        }

        private void ReadJump()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (_player.OnGround)
                {
                    _jumpControl = true;
                }
            }
            else
            {
                _jumpControl = false;
            }

            if (_jumpControl)
            {
                if (_jumpIteration++ < _jumpValueIteration)
                {
                    _playerMovement.Jump(_jumpIteration);
                }
            }
            else
            {
                _jumpIteration = 0;
            }
        }

        void IgnoreLayerOff()
        {
            Physics2D.IgnoreLayerCollision(7,8,false);
        }
    }
}
