using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public readonly float CurrentTempo;

    [SerializeField]
    Song[] SongPlaylist;
    [SerializeField]
    AudioSource[] Audios;
    [SerializeField]
    float Volume;

    int CurrentSongID = 0;
    Song CurrentSong;

    private void Awake()
    {
        CurrentSong = SongPlaylist[0];
        
        Audios[1].volume = 0;
        Audios[2].volume = 0;
        Audios[0].volume = Volume;
    }

    public void ChangeTrack()
    {
        if(CurrentSongID + 1< SongPlaylist.Length)
        {
            
            CurrentSongID += 1;

        }
        else
        {
            CurrentSongID = 0;
           
        }
        
        CurrentSong = SongPlaylist[CurrentSongID];
        Audios[CurrentSongID].volume = Volume;
        foreach(AudioSource AS in Audios)
        {
            if(AS != Audios[CurrentSongID])
            {
                AS.volume = 0;
            }
        }
    }
    
    public float GetTempo()
    {
        return CurrentSong.Tempo;
    }
    public float GetSwitch()
    {
        return CurrentSong.SongSwitchWait;
    }
    public GameObject GetBullet()
    {
        return CurrentSong.Bullet;
    }
}
