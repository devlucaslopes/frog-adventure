using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _playerMovement;
    private PlayerHealth _playerHealth;

    private readonly string TRANSITION_KEY = "transition";

    private enum ANIMATIONS
    {
        idle,
        run,
        jump
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        PlayerHealth.OnHit += HandleHit;
        PlayerRespawn.OnAppearing += HandleAppear;
        CheckpointEnd.OnDesappearing += HandleDesapper;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHit -= HandleAppear;
        PlayerRespawn.OnAppearing -= HandleAppear;
        CheckpointEnd.OnDesappearing -= HandleDesapper;
    }

    private void HandleHit() {
        _animator.SetTrigger("hit");
    }

    private void HandleAppear() {
        _animator.SetTrigger("appearing");
    }

    private void HandleDesapper() {
        _animator.SetTrigger("desappearing");
    }

    private void Update()
    {
        if (_playerMovement.IsJumping) {
            _animator.SetInteger(TRANSITION_KEY, (int) ANIMATIONS.jump);

            if (_playerMovement.Direction > 0) {
                transform.eulerAngles = new Vector3(0, 0, 0);
            } else if (_playerMovement.Direction < 0) {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }

        } else if (_playerMovement.Direction > 0) {
            _animator.SetInteger(TRANSITION_KEY, (int) ANIMATIONS.run);
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (_playerMovement.Direction < 0) {
            _animator.SetInteger(TRANSITION_KEY, (int) ANIMATIONS.run);
            transform.eulerAngles = new Vector3(0, 180, 0);
        } else {
            _animator.SetInteger(TRANSITION_KEY, (int) ANIMATIONS.idle);
        }
    }
}
