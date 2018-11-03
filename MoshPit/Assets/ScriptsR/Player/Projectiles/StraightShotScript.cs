using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShotScript : MonoBehaviour {

	[SerializeField]
    float projectileSpeed, deathTimer;
    Vector3 velocity;
    Rigidbody2D rb;

    private void Awake()
    {
        projectileSpeed *= 1500f;
        velocity = new Vector3(transform.right.x * projectileSpeed, transform.right.y * projectileSpeed, transform.right.z);
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(velocity);
        StartCoroutine("killSelf");
    }

    IEnumerator killSelf()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //kys if ur reading this
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles"))
        {
            Destroy(gameObject);
        }
    }

}
