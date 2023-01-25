using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndLerp : MonoBehaviour
{
    Vector3 _targetPos;
    Vector3 _dragOffset;
    bool _isDragging = false;
    private Camera _cam;
    [SerializeField] private float _negativeBonus;
    [SerializeField] private float _maxDragSpeed;
    [SerializeField] private float _dragAccel;
    [SerializeField] private float _slowdown;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private bool _overreachPosition;
    [SerializeField] private float _lerpSpeed;
    void Awake(){
        _cam = Camera.main;
    }

    void OnMouseOver(){

    }
    void OnMouseDrag(){
        if(!_overreachPosition){
            _targetPos = GetMousePos();
            transform.position = Vector3.MoveTowards(transform.position, _targetPos + _dragOffset, _lerpSpeed * Time.deltaTime);
        }
    }

    void OnMouseDown(){
        _dragOffset = transform.position - GetMousePos();
        _isDragging = true;
    }
    void OnMouseUp(){
        _isDragging = false;
    }
    Vector3 GetMousePos(){
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
    void Update(){
        if(_isDragging && _overreachPosition){
            _targetPos = GetMousePos();
            // transform.position = Vector3.MoveTowards(transform.position, _targetPos + _dragOffset, _lerpSpeed * Time.deltaTime);
            Vector2 difference = _targetPos + _dragOffset - transform.position;
            Vector2 accelVector = difference * _dragAccel * Time.deltaTime;
            Vector2 currentVelocity = _rb.velocity;
            if(Vector2.Dot(accelVector, currentVelocity) < 0){
                accelVector *= _negativeBonus;
            }
            Vector2 drag = -currentVelocity * _slowdown;
            if(currentVelocity.magnitude < 1f){
                drag *= 1f;
            }
            Vector2 targetVelocity = Vector2.ClampMagnitude(currentVelocity + accelVector + drag, _maxDragSpeed);
            _rb.velocity = targetVelocity;
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift)){
            _rb.velocity = Vector3.zero;
        }
    }
}
