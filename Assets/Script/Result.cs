using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] GameObject blackFrame = null;
    [SerializeField] GameObject resultFrame = null;
    [SerializeField] Text[] counts;

    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void ShowResult()
    {
        counts[0].text = scoreManager.perfect.ToString();
        counts[1].text = scoreManager.good.ToString();
        counts[2].text = scoreManager.bad.ToString();
        counts[3].text = scoreManager.miss.ToString();

        blackFrame.GetComponent<Animator>().SetTrigger("End");
        resultFrame.GetComponent<Animator>().SetTrigger("End");
    }

    
}
