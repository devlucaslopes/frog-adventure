using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float Speed;
    [SerializeField] private Transform[] Waypoints;

    private SpriteRenderer _spriteRenderer;

    private int _waypointIndex;

    private void Start() {
        _spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void Update()
    {
        Transform _waypoint = Waypoints[_waypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, _waypoint.position, Speed * Time.deltaTime);

        float _direction = transform.position.x - _waypoint.position.x;

        if (_direction < 0) {
            _spriteRenderer.flipX = true;
        } else {
            _spriteRenderer.flipX = false;
        }

        float _distance = Vector2.Distance(transform.position, _waypoint.position);

        if (_distance <= 0.1f) {
            GetNextWayPointIndex();
        }
    }

    private void GetNextWayPointIndex() {
        _waypointIndex++;

        if (_waypointIndex > Waypoints.Length - 1) {
            _waypointIndex = 0;
        }
    }
}
