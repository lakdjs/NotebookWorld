using System;
using UnityEngine;

namespace PlayerSystem
{
   public class Player : MonoBehaviour
   {
      [field: SerializeField] public float PlayerSpeed { get; private set; }
      [field: SerializeField] public float PlayerJumpForce { get; private set; }
      [field: SerializeField] public int PlayerHPs { get; private set; }
      [field: SerializeField] public Rigidbody2D PlayerRb { get; private set; }
      [field: SerializeField] public Animator PlayerAnimator { get; private set; }
      [field: SerializeField] public SpriteRenderer PlayerSpriteRenderer { get; private set; }
      [field: SerializeField] public Transform LegsTransform { get; private set; }
      [field: SerializeField] public LayerMask Ground { get; private set; }
      [field: SerializeField] public float CheckRadius { get; private set; }
      public bool OnGround { get; private set; }

      private void Start()
      {
         OnGround = false;
         PlayerAnimator = GetComponent<Animator>();
      }

      private void Update()
      {
         OnGround = Physics2D.OverlapCircle(LegsTransform.position, CheckRadius, Ground);
      }
   }
}
