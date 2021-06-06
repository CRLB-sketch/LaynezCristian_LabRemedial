using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static bool initialized = false;
    private static AudioSource audioSource;
    private static Dictionary<AudioClipName, AudioClip> audioClips = 
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Verificar si ya fue inicializado o todavía no
    /// </summary>
    public static bool Initialized
    {
        get { return initialized; }
    }
    
    /// <summary>
    /// Inicializar el Audio Maneger con los audios disponibles
    /// </summary>
    /// <param name="name">nombre del audio que se ejecutará</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;

        // Agregar los sonidos
        addSound(AudioClipName.SFX_Jump_48, "SFX_Jump_48");
        addSound(AudioClipName.flame, "flame");
        addSound(AudioClipName.lava, "lava");
        addSound(AudioClipName.pow, "pow");
    }

    /// <summary>
    /// Se almacenará el audio ingresado en el diccionario de Audio Clips
    /// </summary>
    /// <param name="clipName">nombre del audio que se ejecutará</param>
    /// <param name="audioClip">nombre del audio que se ejecutará</param>
    private static void addSound(AudioClipName clipName, string audioClip)
    {
        audioClips.Add(clipName, Resources.Load<AudioClip>(audioClip));
    }

    /// <summary>
    /// Ejecuta el audio con el clip y nombre incluido
    /// </summary>
    /// <param name="name">nombre del audio que se ejecutará</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
