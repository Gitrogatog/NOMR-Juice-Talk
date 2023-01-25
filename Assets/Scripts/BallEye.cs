using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEye : MonoBehaviour
{
    [SerializeField] private Transform _eyeHolder;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _maxEyeMovement;
    [SerializeField] private float _maxVelocity;
    private Vector2 _ogPosition;

    [SerializeField] private float _collisionEyeShrinkMult;
    [SerializeField] private float _collisionEyeShrinkTime;
    private float _shrinkTimer;
    private bool _isShrink;
    private Vector3 _ogScale;
    private Vector3 _shrinkScale;
    // Start is called before the first frame update
    void Start()
    {
        _ogPosition = _eyeHolder.localPosition;
        _ogScale = _eyeHolder.localScale;
        _shrinkScale = _ogScale;
        _shrinkScale.y = _collisionEyeShrinkMult;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = _rb.velocity;
        float magnitudeRatio = Mathf.Clamp01(velocity.magnitude / _maxVelocity);
        Vector2 offsetPos = velocity.normalized * magnitudeRatio * _maxEyeMovement;
        _eyeHolder.localPosition = _ogPosition + offsetPos;

        if(_shrinkTimer > 0){
            _shrinkTimer -= Time.deltaTime;
            if(_shrinkTimer <= 0){
                _eyeHolder.localScale = _ogScale;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other){
        _eyeHolder.localScale = _shrinkScale;
        _shrinkTimer = _collisionEyeShrinkTime;

    }
}
