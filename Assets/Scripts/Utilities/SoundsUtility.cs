using UnityEngine;

public class SoundsUtility
{
    public static GameObject Play2DSound(AudioClip clip, float volume = 1f)
    {
        GameObject go = new GameObject("OneShotAudio - Custom");
        AudioSource source = go.AddComponent<AudioSource>();

        source.clip = clip;
        source.volume = volume;
        source.spatialBlend = 0f; // 0 = 2D, 1 = 3D
        source.Play();

        return go;
    }
}
