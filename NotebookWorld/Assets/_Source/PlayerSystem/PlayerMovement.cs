using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement : IMovable
    {
        private float _speed;
        private Rigidbody2D _rb;
        private float _jumpforce;
        public PlayerMovement(float speed, Rigidbody2D rb, float jumpforce)
        {
            _speed = speed;
            _rb = rb;
            _jumpforce = jumpforce;
        }
        public void Move(Vector2 dir)
        {
            _rb.velocity = new Vector2(dir.x * _speed, _rb.velocity.y);
        }

        public void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpforce);
        }
    }
}
