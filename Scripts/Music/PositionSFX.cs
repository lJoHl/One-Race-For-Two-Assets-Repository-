using UnityEngine;

namespace Scripts
{
    public class PositionSFX : MonoBehaviour
    {
        // object variable
        private DisappearObjects dOInPSFX = new DisappearObjects();

        // activation variables
        private bool fell;
        private bool started = false;

        // audio variables
        public AudioSource fallSFX;
        public AudioSource carEngineStartSFX;


        // Calls the "Player1" and "Player2" properties of the "DisappearObjects" script and assigns a value to them
        // Also prevents audios from playing when starting the game
        private void Start()
        {
            dOInPSFX.Player1 = GameObject.Find("Player1");
            dOInPSFX.Player2 = GameObject.Find("Player2");

            fallSFX.Stop();
            carEngineStartSFX.Stop();
        }


        private void Update()
        {
            // calls fall method
            Fall();

            // calls car engine start method
            CarEngineStart();
        }



        //_______________________________________________Fall Method________________________________________________
        // Plays the fall audio when falling off the road
        private void Fall()
        {
            if (dOInPSFX.Player1.transform.position.y < -19 | dOInPSFX.Player2.transform.position.y < -19)
                fell = true;
            else
                fell = false;

            if (fell == true & !fallSFX.isPlaying)
                fallSFX.Play();
        }


        //________________________________________Car Engine Start Method______________________________________________
        // Plays car start audio when unfreezing time
        private void CarEngineStart()
        {
            if (started == false)
            {
                if (Time.timeScale == 1 & !carEngineStartSFX.isPlaying)
                {
                    carEngineStartSFX.Play();
                    started = true;
                }
            }
        }

    }
}
