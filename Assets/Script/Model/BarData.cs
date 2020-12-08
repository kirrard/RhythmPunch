using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BarData : MonoBehaviour
{
    public int bar { get; set; }                        // 마디 넘버
    public int channel { get; set; }                    // 채널 넘버
    public List<Dictionary<int, float>> noteDataList { get; set; }   // 노트 정보 <key, time>

    void Awake()
    {
        bar = 0;
        channel = 0;
        noteDataList = new List<Dictionary<int, float>>();
    }

    // debug
    public void Debug()
    {
        print("bar = " + bar);
        print("channel = " + channel);
        foreach (Dictionary<int, float> noteData in noteDataList)
        {
            foreach (int key in noteData.Keys)
            {
                if (key != 0)
                {
                    print("note key = " + key + ", time = " + noteData[key]);
                }
            }
        }
    }
}