using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    [SerializeField] private string m_name;
    [SerializeField] private int m_index;

    public int Index => m_index;
    public string Name => m_name;

    [SerializeField] private TextMeshProUGUI cityName;
    private void Awake()=> cityName.text = m_name;




}
