using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timeOfDayText;

    private void OnEnable()
    {
        GameEvents.OnTimeOfDayChanged += OnTimeOfDayChanged;
    }

    private void OnDisable()
    {
        GameEvents.OnTimeOfDayChanged -= OnTimeOfDayChanged;
    }

    void OnTimeOfDayChanged(TimeOfDay timeOfDay)
    {
        timeOfDayText.text = Utilities.EnumToString(timeOfDay);
    }
}
