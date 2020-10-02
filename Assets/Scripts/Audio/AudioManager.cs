using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = 
    new Dictionary<AudioClipName, AudioClip>();
    
    public static bool Initialized
    {
        get { return initialized; }
    }
    
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.BallCollision,
        Resources.Load<AudioClip>("BallCollision"));
        audioClips.Add(AudioClipName.BallLost,
        Resources.Load<AudioClip>("BallLost"));
        audioClips.Add(AudioClipName.BallSpawn,
        Resources.Load<AudioClip>("BallSpawn"));
        audioClips.Add(AudioClipName.FreezerEffectActivated,
        Resources.Load<AudioClip>("FreezerEffectActivated"));
        audioClips.Add(AudioClipName.FreezerEffectDeactivated,
        Resources.Load<AudioClip>("FreezerEffectDeactivated"));
        audioClips.Add(AudioClipName.GameLost,
        Resources.Load<AudioClip>("GameLost"));
        audioClips.Add(AudioClipName.MenuButtonClick,
        Resources.Load<AudioClip>("MenuButtonClick"));
        audioClips.Add(AudioClipName.SpeedupEffectActivated,
        Resources.Load<AudioClip>("SpeedupEffectActivated"));
        audioClips.Add(AudioClipName.SpeedupEffectDeactivated,
        Resources.Load<AudioClip>("SpeedupEffectDeactivated"));
   }

   public static void Play(AudioClipName name)
   {
       audioSource.PlayOneShot(audioClips[name]);
   }
}
