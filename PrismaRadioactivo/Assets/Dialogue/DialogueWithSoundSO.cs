using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(fileName = "Dialogo", menuName = "ScriptableObjects/Dialogo", order = 1)]
public class DialogueWithSoundSO : ScriptableObject
{
    public string _Texto;
    public AudioClip _AudioVoice;
    
}
