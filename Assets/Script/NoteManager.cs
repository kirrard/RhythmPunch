using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;
    double currentTime = 0;

    [SerializeField] Transform tfNoteAppear = null;
    TimingManager timingManager;
    EffectManager effect;

    // Start is called before the first frame update
    void Start()
    {
        timingManager = GetComponent<TimingManager>();
        effect = FindObjectOfType<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*currentTime += Time.deltaTime;
        if (currentTime >= 60d / bpm)
        {
            GameObject t_note = ObjectPool.instance.noteQueue.Dequeue();
            t_note.transform.position = tfNoteAppear.position;
            t_note.SetActive(true);
            timingManager.boxNoteList.Add(t_note);

            currentTime -= 60d / bpm;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                effect.JudgementEffect(3);
            }

            timingManager.boxNoteList.Remove(collision.gameObject);

            //ObjectPool.instance.noteQueue.Enqueue(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }
}
