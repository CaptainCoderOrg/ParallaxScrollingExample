using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroller : MonoBehaviour
{
    [SerializeField] 
    private GameObject _relativeTo;
    [SerializeField]
    private float _backgroundSpeed;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _leftRenderer;
    private SpriteRenderer _rightRenderer;

    private void Awake()
    {
        InitLeft();
        InitRight();        
    }

    private void InitLeft() => _leftRenderer = InitBackground("Left", -_spriteRenderer.bounds.size.x);
    private void InitRight() => _rightRenderer = InitBackground("Right", +_spriteRenderer.bounds.size.x);

    private SpriteRenderer InitBackground(string name, float xOffset)
    {
        SpriteRenderer newRenderer = Instantiate(_spriteRenderer, transform);
        newRenderer.name = name;
        Vector3 position = _spriteRenderer.transform.position;
        position.x += xOffset;
        newRenderer.transform.position =  position;
        return newRenderer;
    }

    private void Update()
    {
        UpdatePosition();
        CheckSwap();  
    }

    private void UpdatePosition()
    {
        Vector3 position = transform.position;
        position.x = _relativeTo.transform.position.x * _backgroundSpeed;
        transform.position = position;
    }

    private void CheckSwap()
    {
        if(_spriteRenderer.bounds.Contains(_relativeTo.transform.position))
        {
            return;
        }
        bool swapLeftToRight = _relativeTo.transform.position.x - _spriteRenderer.transform.position.x > 0;
        if (swapLeftToRight)
        {
            Vector3 newPosition = _rightRenderer.transform.position;
            newPosition.x += _rightRenderer.bounds.size.x;
            _leftRenderer.transform.position = newPosition;
            (_leftRenderer, _spriteRenderer, _rightRenderer) = (_spriteRenderer, _rightRenderer, _leftRenderer);
        }
        else
        {
            Vector3 newPosition = _leftRenderer.transform.position;
            newPosition.x -= _leftRenderer.bounds.size.x;
            _rightRenderer.transform.position = newPosition;
            (_leftRenderer, _spriteRenderer, _rightRenderer) = (_rightRenderer, _leftRenderer, _spriteRenderer);
        }
    }
}
