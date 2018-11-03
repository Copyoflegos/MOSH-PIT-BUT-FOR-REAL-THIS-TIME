using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumControllerScript : MonoBehaviour {

    [SerializeField]
    GameObject drumProjectile;
    [SerializeField]
    float ShootCDTime;
    Vector3 mousePos;
    Vector3 screenPos;
    bool SHOOT;
    bool ShootCD;
    float AngleGiven;
    float drumsMade;

    private void Awake()
    {
        drumsMade = 0;
        ShootCD = true;
    }

    private void Update()
    {
        SHOOT = Input.GetButton("Shoot");

        if(drumsMade >= 4) { Destroy(gameObject); }

        if (ShootCD)
        {
            Instantiate(drumProjectile, transform.position, Quaternion.Euler(0, 0, 0));
            ShootCD = false;
            StartCoroutine(ShootCoolDownTimer());
        }
    }

    IEnumerator ShootCoolDownTimer()
    {
        yield return new WaitForSeconds(ShootCDTime);
        ShootCD = true;
    }

    public void SetTempo(float newShootCD)
    {
        ShootCDTime = newShootCD;
    }
}
