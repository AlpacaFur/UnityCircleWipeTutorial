using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WipeController : MonoBehaviour
{

    private Animator _animator;
    private Image _image;
    private readonly int _circleSizeId = Shader.PropertyToID("_Circle_Size");
    private bool _isIn = false;
    
    public float circleSize = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
        _image = gameObject.GetComponent<Image>();
    }

    public void AnimateIn()
    {
        _animator.SetTrigger("In");
        _isIn = true;
    }

    public void AnimateOut()
    {
        _animator.SetTrigger("Out");
        _isIn = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_isIn)
            {
                AnimateOut();
            }
            else
            {
                AnimateIn();
            }
        }
        _image.materialForRendering.SetFloat(_circleSizeId, circleSize);
    }
}
