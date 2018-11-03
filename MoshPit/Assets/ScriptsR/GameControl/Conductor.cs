using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    //this class changes bullet type and tempo when music reaches a point
    //then it tells music controller to switch music track

    [SerializeField]
    MusicControl MusicController;
    
    [SerializeField]
    PlayerShootment PlayerShooter;
    

    int ArrayNum = 0;

    

    private void Start()
    {
        PlayerShooter.SetBullet(MusicController.GetBullet());
        PlayerShooter.SetTempo(MusicController.GetTempo());
        StartCoroutine(MusicWait(MusicController.GetSwitch()));
    }
    IEnumerator MusicWait(float MusicCD)
    {
        yield return new WaitForSeconds(MusicCD);
        MusicController.ChangeTrack();
        PlayerShooter.SetBullet(MusicController.GetBullet());
        PlayerShooter.SetTempo(MusicController.GetTempo());

        StartCoroutine(MusicWait(MusicController.GetSwitch()));

    }
}
