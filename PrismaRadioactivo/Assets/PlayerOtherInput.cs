using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerOtherInput : MonoBehaviour
{
    public float CooldownTime;
    private bool bubbleOnCooldown;
    PlayerBubbleController BController;
    private void Start()
    {
        BController = GetComponent<PlayerBubbleController>();
        bubbleOnCooldown = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bubbleOnCooldown) { return; }
            BController.LaunchBubble();
            StartCoroutine(BubbleCooldown());
        }
    }
    IEnumerator BubbleCooldown()
    {
        bubbleOnCooldown = true;
        yield return new WaitForSeconds(CooldownTime);
        bubbleOnCooldown = false;
    }
}
