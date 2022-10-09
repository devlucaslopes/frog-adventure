using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnHit;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Trap")) {
            OnHit?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Trap")) {
            OnHit?.Invoke();
        }
    }
}
