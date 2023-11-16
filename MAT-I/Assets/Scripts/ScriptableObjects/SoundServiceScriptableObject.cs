using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSoundData",menuName = "Data/NewSoundData")]
public class SoundServiceScriptableObject : ScriptableObject
{
    public List<Sound> sounds;
    public void PlaySFX(SoundType soundType,AudioSource audioSource)
    {
        Sound sound = sounds.Find(sound => sound.soundType == soundType);
        if(audioSource != null)
        {
            audioSource.clip = sound.audioClip;
            audioSource.Play();
        }
    }

}

[System.Serializable]
public struct Sound
{
    public AudioClip audioClip;
    public SoundType soundType;
}

public enum SoundType
{
    ItemBought,
    ItemSold
}

