using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void LaunchPlayer(Transform player) {
        float _distance = player.position.y - transform.position.y;

        if (_distance > 0.1f) {
            _animator.SetTrigger("jump");
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player")) {
            LaunchPlayer(other.transform);
        }
    }
}
