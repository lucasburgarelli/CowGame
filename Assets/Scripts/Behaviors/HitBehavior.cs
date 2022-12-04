using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBehavior : MonoBehaviour
{
    public void AnimationFinished()
    {
        Destroy(gameObject);
    }
}
