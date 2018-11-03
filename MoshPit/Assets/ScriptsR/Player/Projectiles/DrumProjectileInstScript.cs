using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumProjectileInstScript : MonoBehaviour {

    [SerializeField]
    float deathTimer;

    private void Awake()
    {
        transform.position += transform.right * 1f;
        StartCoroutine("killSelf");
    }

    IEnumerator killSelf()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }

}
