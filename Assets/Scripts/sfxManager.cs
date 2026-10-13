using UnityEngine;
using UnityEngine.UI;

public class sfxManager : MonoBehaviour
{

    private static sfxManager instance;

    private static AudioSource audioSource;
    private static sfxLibrary sfxLibrary;

    private void Awake()
    {
        
        if(instance == null)
        {
            instance = this;

            audioSource = GetComponent<AudioSource>();
            sfxLibrary = GetComponent<sfxLibrary>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static void Play(string soundName)
    {

        AudioClip audioClip = sfxLibrary.GetRandomClip(soundName);

        if(audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
