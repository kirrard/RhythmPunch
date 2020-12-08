using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatCreator : MonoBehaviour
{
    public int keyMode;

    public float bpm;

    public bool isStart = false;

    float nextTime = 0f;
    float nextSample = 0f;

    float secondPerBar = 0f; // Bar 당 시간(초).
    float secondPerBeat = 0f; // Beat 당 시간(초).
    float samplePerBar = 0f; // Bar 당 PCM 샘플.
    float samplePerBeat = 0f; // Beat 당 PCM 샘플.
    public float beatPerBar; // Bar 당 비트수 (GameManager에서 지정.)

    public float timeRateBySpeed; // 거리 계수

    public AudioClip bgmSound;
    public AudioSource bgmPlayer;
    TimingManager timingManager;

    int beatCount = 0;

    public List<Note> noteObj_Line_1;
    public List<Note> noteObj_Line_2;
    public List<Note> noteObj_Line_3;
    public List<Note> noteObj_Line_4;

    int noteIndex_1 = 0;
    /*int noteIndex_2 = 0;
    int noteIndex_3 = 0;
    int noteIndex_4 = 0;*/

    bool isBgmPlay = false;

    public void SetValues()
    {
        bgmPlayer = gameObject.AddComponent<AudioSource>();
        bgmPlayer.clip = bgmSound;

        timingManager = FindObjectOfType<TimingManager>();

        secondPerBar = 60.0f / bpm * 4f;                            // Bar 당 시간(초)
        secondPerBeat = 60.0f / bpm * 4f / beatPerBar;              // Beat 당 시간(초).
        samplePerBar = secondPerBar * bgmPlayer.clip.frequency;     // Bar 당 PCM 샘플.
        samplePerBeat = secondPerBeat * bgmPlayer.clip.frequency;   // Beat 당 PCM 샘플.

        /*
        foreach(Note note in noteObj_Line_1)
        {
            Debug.Log(note.channel + " " + note.noteTime);
        }*/
    }

    void Update()
    {
        if (isStart == true)
        {
            StartCoroutine(Create()); // 노트생성 코루틴 시작.
        }
    }

    // 노트생성 코루틴.
    IEnumerator Create()
    {
        yield return null;

        if (Time.time >= (secondPerBar * (timeRateBySpeed - 1)) && isBgmPlay == false)
        {
            bgmPlayer.Play();
            isBgmPlay = true;
        }

        if (Time.time >= nextTime && isBgmPlay == false)
        {
            if (noteObj_Line_1.Count > noteIndex_1)
            {
                if (nextTime >= noteObj_Line_1[noteIndex_1].noteTime)
                {
                    noteObj_Line_1[noteIndex_1].isStart = true;
                    noteObj_Line_1[noteIndex_1].gameObject.SetActive(true);
                    timingManager.boxNoteList.Add(noteObj_Line_1[noteIndex_1].gameObject);

                    /*
                    GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                    t_note.transform.position = gameManager.tfNoteAppear.position;
                    t_note.SetActive(true);
                    timingManager.boxNoteList.Add(t_note);
                    */

                    noteIndex_1++;
                }
            }

            nextTime += secondPerBeat;
        }

        //Debug.Log(Time.time + " "+ nextTime + " " + isBgmPlay);

        if (bgmPlayer.timeSamples >= nextSample && isBgmPlay == true)
        {
            if (noteObj_Line_1.Count > noteIndex_1)
            {
                if (bgmPlayer.timeSamples >= (noteObj_Line_1[noteIndex_1].noteTime - (secondPerBar * (timeRateBySpeed - 1))) * bgmPlayer.clip.frequency)
                {
                    noteObj_Line_1[noteIndex_1].isStart = true;
                    noteObj_Line_1[noteIndex_1].gameObject.SetActive(true);
                    timingManager.boxNoteList.Add(noteObj_Line_1[noteIndex_1].gameObject);

                    /*
                    GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
                    t_note.transform.position = gameManager.tfNoteAppear.position;
                    t_note.SetActive(true);
                    timingManager.boxNoteList.Add(t_note);
                    */


                    noteIndex_1++;
                }
            }

            nextSample += samplePerBeat;
            beatCount++;
            Debug.Log(bgmPlayer.timeSamples + " " + nextSample + " " + isBgmPlay);
        }

    }
}