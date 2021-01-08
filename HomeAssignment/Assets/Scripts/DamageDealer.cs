using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int Damage = 0;//Edit from Unity for each obstacle

    public int GetDamage()
    {
        return Damage;
    }

    public void hit()
    {
        Destroy(gameObject);
    }
}
