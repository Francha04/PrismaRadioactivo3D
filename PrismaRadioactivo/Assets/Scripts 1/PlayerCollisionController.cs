using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public PlayerGroupManager thisPlayerGroupM;
    private void Start()
    {
        if (thisPlayerGroupM == null) { thisPlayerGroupM = GetComponent<PlayerGroupManager>(); }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<AldeanoCollider>(out AldeanoCollider coll))
        {
            coll.HitByBubble();
            thisPlayerGroupM.AddZombie();
            FollowPlayer.Instance.UpdateCameraSize(thisPlayerGroupM.AmountOfZombiesChildren);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Killzone")) 
        {
            GameManager.Instance.GameOver();
        }
    }
}