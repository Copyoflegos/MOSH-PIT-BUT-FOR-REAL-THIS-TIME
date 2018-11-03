using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoProjectileScript : MonoBehaviour {

    [SerializeField]
    float deathTimer;

    private void Awake()
    {
        StartCoroutine("killSelf");
    }

    IEnumerator killSelf()
    {
        yield return new WaitForSeconds(deathTimer);
        Destroy(gameObject);
    }
}
