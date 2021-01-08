using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullets : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherObject)//if one of the object itself and hitter is trigger
    {
        Destroy(otherObject.gameObject);
    }

}
