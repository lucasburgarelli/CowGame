using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    private SpriteRenderer _backgroundSprite;
    private float _pulsation = 1f, _pulsationMultiplier = 0.001f;

    private IEnumerator PulseColor()
    {
        var wait = new WaitForSeconds(0.02f);
        while (true)
        {
            _backgroundSprite.color = new Color(_pulsation, _pulsation, _pulsation);
            _pulsation += _pulsationMultiplier;
            if (_pulsation <= 0.7f || _pulsation >= 1) _pulsationMultiplier = -_pulsationMultiplier;
            yield return wait;
        }
    }

    private void Start()
    {
        _backgroundSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(PulseColor());
    }
}
