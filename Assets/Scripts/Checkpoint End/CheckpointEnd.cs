using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointEnd : MonoBehaviour
{
    [Header("Get player")]
    [SerializeField] private Transform GetPlayerPoint;
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private float RadiusCheck;

    public static event Action OnDesappearing;

    private Animator _animator;

    private bool _isPressed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool _hasPlayer = !!Physics2D.OverlapCircle(GetPlayerPoint.position, RadiusCheck, PlayerMask);

        if (_hasPlayer && !_isPressed) {
            _isPressed = true;
            _animator.SetTrigger("isPressed");
            OnDesappearing?.Invoke();

            Invoke(nameof(LevelCompleted), 0.5f);
        }
    }

    private void LevelCompleted() {
        GameManager.Instance.ShowLevelCompleted();
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(GetPlayerPoint.transform.position, RadiusCheck);
    }
}
