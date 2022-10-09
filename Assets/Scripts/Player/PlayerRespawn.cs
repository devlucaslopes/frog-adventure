using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] Transform CheckpointPosition;

    public static event Action OnAppearing;
    public static event Action OnFalling;

    private void Start()
    {
        Respawn();
    }

    private void Respawn() {
        OnAppearing?.Invoke();
        transform.position = CheckpointPosition.position;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Falling Detector")) {
            Respawn();
            OnFalling?.Invoke();
        }
    }
}
