using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject notePrefab;
    public Transform tfNoteAppear;
    public Transform parentNode;

    float beatPerBar = 32f; // Bar 당 비트수.
    int defaultSpeed = 10;
    int timeRateBySpeed = 2; // 거리 계수

    GameObject note;
    BeatCreator beatCreator;

    Note note_sc;

    public string bmsName = "emergency2";

    IEnumerator Start()
    {
        beatCreator = FindObjectOfType<BeatCreator>();

        TextAsset ta = Resources.Load("BmsFiles/" + bmsName) as TextAsset;
        string strData = "" + ta.text;

        string[] lineData = strData.Split('\n');

        // BMS 노트데이터 파싱.
        BmsLoader bmsLoader = GameObject.Find("BmsLoader").GetComponent<BmsLoader>();
        bmsLoader.BmsLoad(lineData);

        Bms bms = bmsLoader.bms;

        // 노트 프리팹 생성 및 리스트 저장.
        List<Note> noteObj_Line_1 = new List<Note>();

        // 노트 생성.
        foreach (BarData barData in bms.barDataList)
        {
            int channel = barData.channel;

            foreach (Dictionary<int, float> noteData in barData.noteDataList)
            {
                foreach (int key in noteData.Keys)
                {
                    // 단노트.
                    if (key != 0 && channel != 16)
                    {
                        float noteTime = noteData[key];

                        note = Instantiate(notePrefab, tfNoteAppear.position, Quaternion.identity);
                        note.SetActive(false);
                        note.transform.SetParent(parentNode);
                        note.transform.localScale = notePrefab.transform.localScale;

                        note_sc = note.GetComponent<Note>();
                        note_sc.speed = defaultSpeed;
                        note_sc.noteTime = noteTime;
                        note_sc.channel = channel;

                        if (channel == 11)
                        {
                            noteObj_Line_1.Add(note_sc);
                        }
                        /*else if (channel == 12)
                        {
                            noteObj_Line_2.Add(note_sc);
                        }
                        else if (channel == 13)
                        {
                            noteObj_Line_3.Add(note_sc);
                        }
                        else if (channel == 14)
                        {
                            noteObj_Line_4.Add(note_sc);
                        }
                        else if (channel == 15)
                        {
                            noteObj_Line_5.Add(note_sc);
                        }*/
                    }
                }
            }
        }

        noteObj_Line_1.Sort(delegate (Note a, Note b) {
            return a.noteTime.CompareTo(b.noteTime);
        });
        /*noteObj_Line_2.Sort(delegate (NoteObj_sc a, NoteObj_sc b) {
            return a.noteTime.CompareTo(b.noteTime);
        });
        noteObj_Line_3.Sort(delegate (NoteObj_sc a, NoteObj_sc b) {
            return a.noteTime.CompareTo(b.noteTime);
        });
        noteObj_Line_4.Sort(delegate (NoteObj_sc a, NoteObj_sc b) {
            return a.noteTime.CompareTo(b.noteTime);
        });
        noteObj_Line_5.Sort(delegate (NoteObj_sc a, NoteObj_sc b) {
            return a.noteTime.CompareTo(b.noteTime);
        });
        */

        // 비트 크리에이터.

        beatCreator.noteObj_Line_1 = noteObj_Line_1;

        beatCreator.bpm = (float)bms.bpm;
        beatCreator.beatPerBar = beatPerBar;
        beatCreator.timeRateBySpeed = timeRateBySpeed;

        beatCreator.SetValues();

        AudioClip bgm = Resources.Load("Sound/" + bmsName) as AudioClip;
        beatCreator.bgmSound = bgm;

        // 모든 렌더링작업이 끝날 때까지 대기
        yield return new WaitForEndOfFrame();

        beatCreator.isStart = true; // 시작
    }
}