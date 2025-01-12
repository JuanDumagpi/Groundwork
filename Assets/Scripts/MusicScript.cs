using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicScript : MonoBehaviour

{   private static MusicScript instance;
    private AudioSource musicSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        //makes sure no multiple bgms play
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {   //music keeps going between loading a new scene if the same gameobject is there
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
    public void PlayMusic()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.Play();
    }
}
