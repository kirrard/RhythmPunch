using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int bpm = 0;

    TimingManager timingManager;
    EffectManager effect;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        timingManager = GetComponent<TimingManager>();
        effect = FindObjectOfType<EffectManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Note"))
        {
            if (collision.GetComponent<Note>().GetNoteFlag())
            {
                effect.JudgementEffect(3);
                scoreManager.IncreaseScore(3);
            }

            timingManager.boxNoteList.Remove(collision.gameObject);
            
            collision.gameObject.SetActive(false);
        }
    }
}
