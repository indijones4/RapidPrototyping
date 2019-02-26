using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum TimeOfDay { MorningTime, DayTime, EveningTime, NightTime }

public class TimeCycle : MonoBehaviour
{
    public bool RandomTime = false;
    public TimeOfDay timeOfDay;
    Light lightSource;
    float transitionTime = 2f;

    [Header("Timers")]
    public int currentTime;
    public float timeModifier = 1;
    bool stopped = false;

    [Header("Sky Colours")]
    public Color morningColour;
    public Color dayTimeColour;
    public Color afternoonColour;
    public Color nightColour;

    // Start is called before the first frame update
    void Start()
    {
        timeOfDay = TimeOfDay.MorningTime;
        lightSource = GetComponent<Light>();
        currentTime = 0;
        StartCoroutine(TickTock());
    }

    void ChangeTime()
    {
        #region old
        //if (RandomTime)
        //{
        //    timeOfDay = Utilities.RandomEnumValue<TimeOfDay>();
        //    randomTime = false;
        //}
        //else
        //{
        //    if ((int)timeOfDay == Utilities.EnumLength(timeOfDay))
        //        timeOfDay = 0;
        //    else
        //        timeOfDay++;
        //}

        //Debug.Log(Utilities.EnumToString(timeOfDay));
        #endregion

        timeOfDay = GetTimeOfDay();

        switch (timeOfDay)
        {
            case TimeOfDay.MorningTime:
                lightSource.DOColor(morningColour, transitionTime);
                break;
            case TimeOfDay.DayTime:
                lightSource.DOColor(dayTimeColour, transitionTime);
                break;
            case TimeOfDay.EveningTime:
                lightSource.DOColor(afternoonColour, transitionTime);
                break;
            case TimeOfDay.NightTime:
                lightSource.DOColor(nightColour, transitionTime);
                break;
        }

        GameEvents.ReportOnTimeOfDayChange(timeOfDay);
    }

    TimeOfDay GetTimeOfDay()
    {
        switch (currentTime)
        {
            case 6:
            case 7:
            case 8:
            case 9:
                return TimeOfDay.MorningTime;
            case 10:
            case 11:
            case 12:
            case 13:
            case 14:
            case 15:
            case 16:
                return TimeOfDay.DayTime;
            case 17:
            case 18:
            case 19:
            case 20:
            case 21:
                return TimeOfDay.EveningTime;
            default:
                return TimeOfDay.NightTime;
        }
    }

   // void RandomTime()
   // {
   //     Debug.Log(Utilities.RandomEnumValue<TimeOfDay>());
   // }

    IEnumerator TickTock()
    {
        while (!stopped)
        {
            yield return new WaitForSeconds(timeModifier);
            if (currentTime == 23)
                currentTime = 0;
            else
                currentTime++;

            ChangeTime();
        }
    }
}
