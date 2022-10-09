using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float Delay;
    [SerializeField] private float Duration;

    [Header("Get player")]
    [SerializeField] private Transform GetPlayerPoint;
    [SerializeField] private LayerMask PlayerMask;
    [SerializeField] private float RadiusCheck;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bool _hasPlayer = !!Physics2D.OverlapCircle(GetPlayerPoint.transform.position, RadiusCheck, PlayerMask);

        if (_hasPlayer)
            StartCoroutine(TurnOnFire());
    }

    IEnumerator TurnOnFire() {
        yield return new WaitForSeconds(Delay);

        _animator.SetBool("turnOn", true);

        yield return new WaitForSeconds(Duration);

        _animator.SetBool("turnOn", false);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(GetPlayerPoint.transform.position, RadiusCheck);
    }
}
