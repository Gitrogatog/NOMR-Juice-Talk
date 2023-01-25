using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    Vector3 _targetPos;
    Vector3 _dragOffset;
    bool _isDragging = false;
    private Camera _cam;
    [SerializeField] private float _lerpSpeed = 10f;
    [SerializeField] private bool _enabled;
    void Awake(){
        _cam = Camera.main;
    }

    void OnMouseDown(){
        _dragOffset = transform.position - GetMousePos();
    }
    void OnMouseDrag(){
        Debug.Log("Dragging!");
        _targetPos = GetMousePos();
        transform.position = Vector3.MoveTowards(transform.position, _targetPos + _dragOffset, _lerpSpeed * Time.deltaTime);
        _isDragging = true;
    }
    Vector3 GetMousePos(){
        Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
