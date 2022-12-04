using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _menuVictory;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(!col.gameObject.CompareTag("Player")) return;
        
        Time.timeScale = 0;
        Cursor.visible = true;
        _menuVictory.SetActive(true);
    }
}
