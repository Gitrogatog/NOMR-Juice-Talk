using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StretchBall : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float maxStretch;
    [SerializeField] private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = _rb.velocity;
        float magnitudeRatio = Mathf.Clamp01(velocity.magnitude / maxVelocity);
        if(true){
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg - 90f;
            _transform.eulerAngles = new Vector3(0, 0, angle);
            float stretchAmount = Mathf.Max(1 + magnitudeRatio * (maxStretch - 1), 1f);
            _transform.localScale = new Vector3(1 / stretchAmount, stretchAmount, 1);
        }
    }
}
