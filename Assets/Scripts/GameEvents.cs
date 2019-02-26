using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action<TimeOfDay> OnTimeOfDayChanged = null;

    public static void ReportOnTimeOfDayChange(TimeOfDay timeOfDay)
    {
        if (OnTimeOfDayChanged != null)
            OnTimeOfDayChanged(timeOfDay);
    }
}