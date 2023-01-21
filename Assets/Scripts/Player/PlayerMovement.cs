using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private float _moveDirection;

    private Rigidbody2D _rb;
    private Animator _animator;

    private float _lastRBVelocityX = 0;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _moveDirection = Input.GetAxis("Horizontal");
        CheckAnimation();
        CheckDirection();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(new Vector2(_moveDirection, 0) * (moveSpeed * Time.fixedDeltaTime));
    }

    private void CheckDirection()
    {
        if (_lastRBVelocityX <= 0 && _rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        } else if (_lastRBVelocityX >= 0 && _rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void CheckAnimation()
    {
        _animator.SetLayerWeight(1, Mathf.Clamp(RemapForAnimation(Mathf.Abs(_rb.velocity.x), 0.1f, 3, 0, 1), 0, 1));
    }
    
    
    private float RemapForAnimation (float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
