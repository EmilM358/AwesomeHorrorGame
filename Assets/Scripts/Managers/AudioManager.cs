using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<AudioClip, float> lastPlayedTime = new Dictionary<AudioClip, float>();
    public static AudioManager instance;

    [Header("Audio Sources (Do not Add)")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Player SFX")]
    public AudioClip hurt;
    public AudioClip steps;

    [Header("Puzzle SFX")]
    public AudioClip scavengeSpot;
    public AudioClip flask;
    public AudioClip mixmachine;

    [Header("Spider SFX")]
    public AudioClip babyEat;
    public AudioClip babyCry;

    [Header("Player Footsteps")]
    public List<AudioClip> playerSteps;

    [Header("Footstep Timing")]
    public float playerStepInterval = 0.5f;
    public float fluffyStepInterval = 0.4f;
    float lastPlayerStepTime;
    float lastFluffyStepTime;

    [Header("Music")]
    public AudioClip ambience;
    public AudioClip tenseMusic;
    [Range(0f, 1f)]
    public float musicVolume = 0.3f;

    [Header("SFX Settings")]
    public float sfxCooldown = 0.1f;
    public float sfxVolume = 0.1f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (sfxSource == null)
            sfxSource = gameObject.AddComponent<AudioSource>();

        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        musicSource.loop = true;
        musicSource.volume = musicVolume;

        if (ambience != null)
        {
            musicSource.clip = ambience;
            musicSource.Play();
        }
    }

    public void PlaySFX(AudioClip clip, float cooldown = 0.1f)
    {
        if (clip == null || sfxSource == null) return;

        if (lastPlayedTime.TryGetValue(clip, out float lastTime))
        {
            if (Time.time - lastTime < cooldown)
                return;
        }

        sfxSource.PlayOneShot(clip, sfxVolume);
        lastPlayedTime[clip] = Time.time;
    }

    public void PlayPlayerFootstep()
    {
        if (playerSteps == null || playerSteps.Count == 0) return;

        if (Time.time - lastPlayerStepTime < playerStepInterval)
            return;

        AudioClip clip = playerSteps[Random.Range(0, playerSteps.Count)];
        PlaySFX(clip, sfxCooldown);

        lastPlayerStepTime = Time.time;
    }
}