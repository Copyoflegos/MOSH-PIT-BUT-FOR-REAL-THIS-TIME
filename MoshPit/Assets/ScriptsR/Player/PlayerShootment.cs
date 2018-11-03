using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootment : MonoBehaviour
{
    public float ShootCDTime;
    public GameObject currentBullet;
    Vector3 mousePos;
    Vector3 screenPos;
    bool SHOOT;
    bool ShootCD;
    float AngleGiven;
    float DrumsShot;
    private void Awake()
    {
        ShootCD = true;
        DrumsShot = 0;
    }
    private void Update()
    {
        SHOOT = Input.GetButton("Shoot");

        mousePos = Input.mousePosition;
        screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));

        AngleGiven = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x)) * Mathf.Rad2Deg;

        if (ShootCD)
        {
            if (currentBullet.gameObject.name == "DrumProjectile")
            {
                if (DrumsShot < 3)
                {
                    Instantiate(currentBullet, transform.position + new Vector3(screenPos.x / 2, screenPos.y / 2, screenPos.z), Quaternion.Euler(0, 0, AngleGiven));
                }
                else
                {
                    Instantiate(currentBullet, transform.position + new Vector3(screenPos.x / 2, screenPos.y / 2, screenPos.z), Quaternion.Euler(0, 0, AngleGiven));
                    Debug.Log("BigBoy");
                }
                Debug.Log(DrumsShot);
                DrumsShot += 1;
            }
            else
            {
                Instantiate(currentBullet, transform.position, Quaternion.Euler(0, 0, AngleGiven));
            }
            if(DrumsShot >= 4) { DrumsShot = 0; }
            ShootCD = false;
            StartCoroutine(ShootCoolDownTimer());
        }
    }
    IEnumerator ShootCoolDownTimer()
    {
        yield return new WaitForSeconds(ShootCDTime);
        ShootCD = true;
    }

    public void SetBullet(GameObject newBullet)
    {
        currentBullet = newBullet;
    }
    public void SetTempo(float newShootCD)
    {
        ShootCDTime = newShootCD;
    }
}
