using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class PlayerDialogueManager : MonoBehaviour
{
    List<DialogueWithSoundSO> m_Dialogues;
    public DialogueWithSoundSO InitialDialogue;

    public float dialogueFadeTime;
    public int dialogueIndex;
    public float DialogueDurationTime;
    public TextMeshPro ThisText;
    public AudioSource ThisSource;
    public static PlayerDialogueManager Instance { get; private set; }
    private void Start()
    {
        ThisText.text = "";
        dialogueIndex = 0;
        SpawnInitialDialogue();
    }
    public void SpawnInitialDialogue() {
        SpawnNextDialogue(InitialDialogue);
    }
    public void SpawnNextZombieDialogue() 
    {
        if (dialogueIndex > m_Dialogues.Count-1) { dialogueIndex = 0; }
        SpawnNextDialogue(m_Dialogues[dialogueIndex]);
    }
    private void SpawnNextDialogue(DialogueWithSoundSO thisDialog) 
    {
        ThisText.text = thisDialog._Texto;
        ThisSource.clip = thisDialog._AudioVoice;
        ThisSource.Play();
        StartCoroutine(DialogueDuration());
    }
    IEnumerator DialogueDuration() 
    {
        yield return new WaitForSeconds(DialogueDurationTime);
        CloseDialogue();
    }
    public void CloseDialogue() 
    {
        ThisText.DOFade(0f, dialogueFadeTime).OnComplete(()=> { ThisText.text = ""; });
        
    }
}
