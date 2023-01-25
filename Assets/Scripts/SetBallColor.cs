using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBallColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private bool _lerpColor;
    private Color _targetColor;
    [SerializeField] private float _changeTime;
    private float _colorTimer;
    private bool _isChanging = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isChanging){
            _colorTimer += Time.deltaTime / _changeTime;
            _renderer.color = Color.Lerp(_renderer.color, _targetColor, _colorTimer);
            if(_colorTimer >= 1f){
                _isChanging = false;
            }
        }
    }
    public void ChangeColor(Color newColor){
        if(!_lerpColor) _renderer.color = newColor;
        else {
            _targetColor = newColor;
            _isChanging = true;
            _colorTimer = 0;
        }
    }
}
