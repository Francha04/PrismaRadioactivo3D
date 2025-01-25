using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.TryGetComponent<AldeanoCollider>(out AldeanoCollider coll))
        {
            coll.HitByBubble();
            PlayerGroupManager.Instance.AddZombie();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

    }
}
