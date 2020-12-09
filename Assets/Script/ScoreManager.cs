using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int perfect { get; set; } = 0;
    public int good { get; set; } = 0;
    public int bad { get; set; } = 0;
    public int miss { get; set; } = 0;

    public void IncreaseScore(int x)
    {
        switch(x)
        {
            case 0:
                perfect++;
                break;
            case 1:
                good++;
                break;
            case 2:
                bad++;
                break;
            case 3:
                miss++;
                break;
            default:
                break;
        }
    }
}
