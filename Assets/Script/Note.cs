using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour
{
    public Animator animator;
    Image noteImage;
    NoteManager noteManager;

    public int speed;
    public bool isStart = false;

    public int channel;
    public float noteTime;

    private void OnEnable()
    {
        noteManager = FindObjectOfType<NoteManager>();

        if (noteImage == null)
        {
            noteImage = GetComponent<Image>();
            animator = GetComponent<Animator>();
        }

        noteImage.enabled = true;
    }

    public void HideNote()
    {
        noteImage.enabled = false;
    }

    public bool GetNoteFlag()
    {
        return noteImage.enabled;
    }
}
