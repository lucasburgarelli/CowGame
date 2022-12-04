using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotImpactBehavior : MonoBehaviour
{
    private IEnumerator IDestroy()
    {
        var wait = new WaitForSeconds(2);
        var destroy  = false;
        while (!destroy)
        {
            destroy = true;
            yield return wait;
        }
        Destroy(gameObject);
    }
    
    private void Start()
    {
        StartCoroutine(IDestroy());
    }
}
