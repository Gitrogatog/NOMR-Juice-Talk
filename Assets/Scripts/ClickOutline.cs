using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOutline : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _outline;
    [SerializeField] private OutlineData _regularOutline;
    [SerializeField] private OutlineData _mouseOverOutline;
    // [SerializeField] private OutlineData _clickOutline;
    private bool _isMouseDown;
    private bool _isClicked;

    // Start is called before the first frame update
    void Awake()
    {
        _regularOutline.scale = new Vector3(_regularOutline.size, _regularOutline.size, 1);
        _mouseOverOutline.scale = new Vector3(_mouseOverOutline.size, _mouseOverOutline.size, 1);
        // _clickOutline.scale = new Vector3(_clickOutline.size, _clickOutline.size, 1);
        SetOutline(_regularOutline);
    }

    void OnMouseOver(){
        SetOutline(_mouseOverOutline);
    }
    void OnMouseExit(){
        SetOutline(_regularOutline);
    }
    void OnMouseDown(){
        // SetOutline(_clickOutline);
    }
    void OnMouseUp(){
        SetOutline(_mouseOverOutline);
    }

    void SetOutline(OutlineData outlineData){
        _outline.transform.localScale = outlineData.scale;
        _outline.color = outlineData.color;
    }

    void UpdateMouseDown(bool mouseDown){
        
    }
    void UpdateClicked(bool clicked){

    }
    [System.Serializable]
    private struct OutlineData{
        public float size;
        public Color color;
        [HideInInspector] public Vector3 scale;
    }
}
