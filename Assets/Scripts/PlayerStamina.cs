using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStamina : MonoBehaviour
{
    private Animator _animator;

    public float staminaDepletePerSecond = 15;
    public float staminaGainPerSecond = 25;

    public float maxStamina = 100;
    
    private float _stamina = 100;

    private PlayerMovement _playerMovement;

    private Coroutine _staminaHandle;

    private Rigidbody2D _rb;

    private float _startingRBDrag;
    private float _startMoveSpeed;

    public float tiredRBDrag;
    public float tiredMoveSpeed;

    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        _startMoveSpeed = _playerMovement.moveSpeed;
        _startingRBDrag = _rb.drag;
    }

    private void OnEnable()
    {
        
        _stamina = maxStamina;
        _staminaHandle = StartCoroutine(UseStaminaRoutine());
    }

    private void OnDisable()
    {
        StopCoroutine(_staminaHandle);
    }

    private IEnumerator UseStaminaRoutine()
    {
        while (true)
        {
            
            float lastStamina = _stamina;
            
            if (_rb.velocity.magnitude > 0.1f)
            {
                _stamina = Mathf.Clamp(_stamina - staminaDepletePerSecond * Time.deltaTime, 0, maxStamina);
            }
            else
            {
                _stamina = Mathf.Clamp(_stamina + staminaGainPerSecond * Time.deltaTime, 0, maxStamina);
            }

            
            if (_stamina == 0 && lastStamina > 0)
            {
                _animator.SetBool("Tired", true);
                _rb.drag = tiredRBDrag;
                _playerMovement.moveSpeed = tiredMoveSpeed;
            }

            if (_stamina > 0 && lastStamina == 0)
            {
                _animator.SetBool("Tired", false);
                _rb.drag = _startingRBDrag;
                _playerMovement.moveSpeed = _startMoveSpeed;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
