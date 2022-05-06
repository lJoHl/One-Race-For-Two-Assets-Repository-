using UnityEngine;

public class BGM : MonoBehaviour
{
    // audio variables
    public AudioSource startBGM;
    public AudioSource playBGM_intro;
    public AudioSource playBGM_loop;
    public AudioSource endBGM;

    // activation variables
    private bool playBGM_introPlayed = false;


    // Prevents audios from playing when starting the game
    private void Start()
    {
        playBGM_intro.Stop();
        playBGM_loop.Stop();
        endBGM.Stop();
    }


    // It is in charge of activating and/or deactivating the audios; "startBGM" and "playBGM", based on whether time is frozen or not
    private void Update()
    {
        if (Time.timeScale == 0 & !startBGM.isPlaying)
        {
            startBGM.Play();
        }
        else if (Time.timeScale == 1)
        {
            startBGM.Stop();

            if (playBGM_introPlayed == false & !playBGM_intro.isPlaying & !endBGM.isPlaying)
            {
                playBGM_intro.Play();
                playBGM_introPlayed = true;
            }

            if (playBGM_introPlayed == true & !playBGM_intro.isPlaying & !playBGM_loop.isPlaying & !endBGM.isPlaying)
                playBGM_loop.Play();
        }
    }


    // Disables the "playBGM" and enables "endBGM" when colliding with the goal
    private void OnCollisionEnter()
    {
        if (!endBGM.isPlaying)
        {
            playBGM_intro.Stop();
            playBGM_loop.Stop();
            endBGM.Play();
        }
    }
}
