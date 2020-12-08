using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bms : MonoBehaviour
{
    public string title { get; set; }               // 타이틀
    public string artist { get; set; }              // 아티스트
    public double bpm { get; set; }                 // BPM
    public List<BarData> barDataList { get; set; }  // 노트 데이터 리스트
    public int lnType { get; set; }                 // 롱노트 타입

    public int totalBarCount { get; set; }          // 총 Bar 수
    public int totalNoteCount { get; set; }         // 총 노트 수
    public float totalPlayTime { get; set; }        // 총 재생 시간

    void Awake()
    {
        title = "";
        artist = "";
        bpm = 0;
        barDataList = new List<BarData>();
        totalNoteCount = 0;
        totalPlayTime = 0;
        lnType = 0;
    }

    // add
    public void AddBarData(BarData bar)
    {
        barDataList.Add(bar);
    }

    // sum
    public void SumTotalNoteCount()
    {
        totalNoteCount++;
    }

    // debug
    public void Debug()
    {
        print("title = " + title);
        print("artist = " + artist);
        print("bpm = " + bpm);
        print("long note type = " + lnType);
        print("total bar Count = " + barDataList.Count);
        print("total note Count = " + totalNoteCount);
        print("total play time = " + totalPlayTime);
    }
}