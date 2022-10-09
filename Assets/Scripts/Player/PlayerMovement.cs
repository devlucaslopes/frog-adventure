using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float Speed;
    [SerializeField] private float JumpForce;

    [Header("Ground Detector")]
    [SerializeField] private float Range;
    [SerializeField] private Transform RightFoot;
    [SerializeField] private Transform LeftFoot;
    [SerializeField] private LayerMask GroundLayer;

    private Rigidbody2D _body;
    
    private int _direction = 0;
    private Vector2 _jumpImpulse;
    private Vector2 _doubleJumpImpulse;
    private bool _onGround;
    private bool _isJumping;
    private bool _canMove = true;

    public int Direction { get => _direction; }
    public bool IsJumping { get => _isJumping; }

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();

        _jumpImpulse = Vector2.up * JumpForce;
    }

    private void OnEnable()
    {
        CheckpointEnd.OnDesappearing += HandleDesapper;
    }

    private void OnDisable()
    {
        CheckpointEnd.OnDesappearing -= HandleDesapper;
    }

    private void HandleDesapper() {
        _canMove = false;
    }

    private void Update() {
        PhysicsCheck();
    }

    private void FixedUpdate() {
        if (!_canMove)
            return;

        _body.velocity = new Vector2(_direction * Speed, _body.velocity.y);
    }

    public void SetDirection(int value) {
        _direction = value;
    }

    public void Jump() {
        if (_onGround && !_isJumping) {
            _isJumping = true;

            _body.AddForce(_jumpImpulse, ForceMode2D.Impulse);
        }
    }

    private void PhysicsCheck() {
        _onGround = false;
        _isJumping = false;

        bool _rightFoot = !!Physics2D.Raycast(RightFoot.position, Vector2.down, Range, GroundLayer);
        bool _leftFoot = !!Physics2D.Raycast(LeftFoot.position, Vector2.down, Range, GroundLayer);

        if (_rightFoot || _leftFoot) {
            _onGround = true;
        } else {
            _isJumping = true;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(RightFoot.position, Vector2.down * Range);
        Gizmos.DrawRay(LeftFoot.position, Vector2.down * Range);
    }
}
