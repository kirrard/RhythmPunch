using System.Collections.Generic;
using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public List<GameObject> boxNoteList = new List<GameObject>();

    [SerializeField] Transform center = null;
    [SerializeField] RectTransform[] timingRect = null;
    Vector2[] timingBoxs = null;

    EffectManager effect;
    ScoreManager scoreManager;

    void Start()
    {
        effect = FindObjectOfType<EffectManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        timingBoxs = new Vector2[timingRect.Length];

        for (int i = 0; i < timingRect.Length; i++)
        {
            timingBoxs[i].Set(center.localPosition.x - timingRect[i].rect.width / 2,
                              center.localPosition.x + timingRect[i].rect.width / 2);
        }
    }

    public bool CheckTiming()
    {
        for (int i = 0; i < boxNoteList.Count; i++)
        {
            float t_noteBoxX = boxNoteList[i].transform.localPosition.x;

            for (int x = 0; x < timingBoxs.Length; x++)
            {
                if (timingBoxs[x].x <= t_noteBoxX && t_noteBoxX <= timingBoxs[x].y)
                {
                    if (x < timingBoxs.Length - 1)
                    {
                        effect.NoteHitEffect();
                    }

                    effect.JudgementEffect(x);
                    scoreManager.IncreaseScore(x);
                    boxNoteList[i].GetComponent<Animator>().SetTrigger("Hit");
                    boxNoteList[i].GetComponent<AudioSource>().Play();

                    return true;
                }
            }
        }

        return false;
    }
}
