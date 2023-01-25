using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandAimer : MonoBehaviour
{
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _turnAccel;
    [SerializeField] private Transform _transform;
    private float _targetTurnSpeed;
    private float _currentTurnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = -Input.GetAxisRaw("Horizontal");
        _currentTurnSpeed = Mathf.MoveTowards(_currentTurnSpeed, horizontal * _turnSpeed, _turnAccel * Time.deltaTime);
        _transform.Rotate(0, 0, _currentTurnSpeed);
    }
}
