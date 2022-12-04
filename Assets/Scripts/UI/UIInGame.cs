using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInGame : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshHp, _textMeshEnergy;

    [SerializeField] private GameObject _menuPause;
    
    public void SetHpAndEnergy(int hp, int energy)
    {
        _textMeshHp.text = "Hp: " + hp;
        _textMeshEnergy.text = "Energy: " + energy;
    }

    public void Pause()
    {
        _menuPause.SetActive(true);
    }
}
