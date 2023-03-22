using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CostView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TMP_Text _cost;

    private void Awake()
    {
        
    }

    public void UpdateInfo(float value)
    {
        _cost.text = $"{value}";
    }
}
