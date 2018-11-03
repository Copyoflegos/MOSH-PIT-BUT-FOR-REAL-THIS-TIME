using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHitBoxScript : MonoBehaviour
{
    //[SerializeField]
    float enemyHealth;

    // Use this for initialization
    void Start()
    {
        enemyHealth = 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("PlayerProjectile"))
        {
            enemyHealth -= float.Parse(collision.gameObject.GetComponent<Text>().text);
            if(enemyHealth <= 0)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }


}