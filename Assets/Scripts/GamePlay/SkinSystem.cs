using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using System;

public enum SkinTypeEnum{
    DEFAULT = 0,
    SUMMER = 1,    
}
public static class SpecialEventTimeEnum{
    public static readonly string SUMMER = "5/1/2023 11:59:59 AM-8/15/2023 11:59:59 AM";
}

public class SpecialEvent{
    public DateTime StartTime;
    public DateTime EndTime;
    public SkinTypeEnum SkinType;
    public SpecialEvent(string specialEventTime, SkinTypeEnum skinType){
        SkinType = skinType;
        DateTime currentDate = DateTime.Now;
        try{
            string[] sub = specialEventTime.Split('-');
            StartTime = DateTime.Parse(sub[0]);
            EndTime = DateTime.Parse(sub[1]);
            StartTime = new DateTime(currentDate.Year,StartTime.Month,StartTime.Day,StartTime.Hour,StartTime.Minute,StartTime.Millisecond);
            EndTime = new DateTime(currentDate.Year,EndTime.Month,EndTime.Day,EndTime.Hour,EndTime.Minute,EndTime.Millisecond);
        }
        catch(Exception e){
            Debug.LogException(e);
        }
    } 
    public bool IsTimeOfEvent(DateTime day){
        if(DateTime.Compare(day,StartTime) >= 0 && DateTime.Compare(day,EndTime) < 0){
            return true;
        }
        return false;
    }
}
public class SkinSystem : Singleton<SkinSystem>
{   
    public SkinTypeEnum SkinType;
    private List<SpecialEvent> _specialEvents;
    void Start()
    {
        _specialEvents = new List<SpecialEvent>();
        _specialEvents.Add(
            new SpecialEvent(SpecialEventTimeEnum.SUMMER,SkinTypeEnum.SUMMER)
            );
        ChoosingSkinBySeason();
    }
    public void ChoosingSkinBySeason(){
        SkinType = SkinTypeEnum.DEFAULT;
        foreach (var specialEvent in _specialEvents)
        {
            if(specialEvent.IsTimeOfEvent(DateTime.Now)){
                SkinType = specialEvent.SkinType;
                break;
            }
        }
    }
}
