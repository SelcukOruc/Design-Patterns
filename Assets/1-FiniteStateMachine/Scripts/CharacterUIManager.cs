using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI state;

    public void SetText(string _text)
    {
        if (state == null)
            return;

        state.text = string.Format("State: {0}", _text);
    }

}
