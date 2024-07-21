using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandUIElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI msg;
    public void SetInfo(string _cityName)
    {
        msg.text = string.Format("Moved To: {0}", _cityName);
    }

}
