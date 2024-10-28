using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    [Header("audioManage")]
    public static AudioManager instance;

    [Header("Volume")]
    public VolumeSaveControler volumeSave;
    public float masterVolume = 0.5f;
    public float masterVolumeEstresse = 0.5f;
    private Bus masterbus;
    private Bus masterEstressebus;
    private Bus masterMusicaBus;
    private Bus masterTelevisionaBus;

    private void Awake(){
        instance = this;
        masterVolume = volumeSave.Volume;

        masterbus = RuntimeManager.GetBus("bus:/");
        masterMusicaBus = RuntimeManager.GetBus("bus:/Musica");
        masterEstressebus = RuntimeManager.GetBus("bus:/respiração");
        masterTelevisionaBus = RuntimeManager.GetBus("bus:/television");
    }
    

    public void PlayEvent(EventReference sound,Vector3 pos)
    {
        RuntimeManager.PlayOneShot(sound,pos);
    }


    public void SetVolume(float nVolume,string busstr)
    {
        volumeSave.Volume = nVolume;
        switch (busstr)
        {
            case "master":
                masterVolume = nVolume;
                masterbus.setVolume(masterVolume);
                break;
            case "estresse":
                masterVolumeEstresse = nVolume;
                // volumeSave.Volume = nVolume;
                masterEstressebus.setVolume(masterVolumeEstresse);
                break;
            case "musica":
                masterMusicaBus.setVolume(nVolume); 
                break;
            case "tv":
                masterTelevisionaBus.setVolume(nVolume); 
            break;
        }
    }

    public float GetVolume()
    {
       return masterVolume;
    }
}
