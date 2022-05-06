using UnityEngine;

namespace Scripts
{
    public class CollisionSFX : MonoBehaviour
    {
        // activation variables
        private bool winSFXPlayed = false;

        // audio variables
        public AudioSource boxCollisionSFX;
        public AudioSource coneCollisionSFX;
        public AudioSource busCollisionSFX;
        public AudioSource carCollisionSFX;
        public AudioSource winSFX;


        // Prevents audios from playing when starting the game
        private void Start()
        {
            boxCollisionSFX.Stop();
            coneCollisionSFX.Stop();
            busCollisionSFX.Stop();
            carCollisionSFX.Stop();
            winSFX.Stop();
        }


        // This reproduces a certain sound, when the player collides with a certain object
        private void OnCollisionEnter(Collision collsion)
        {
            switch (collsion.gameObject.name)
            {
                case "Crate_01_ZUp":
                case "Crate_01_XRight":
                case "Crate_01_ZDown":

                    if (!boxCollisionSFX.isPlaying)
                        boxCollisionSFX.Play();

                    break;

                case "Prop_Cone_01_ZUp":
                case "Prop_Cone_01_ZDown":

                    if (!coneCollisionSFX.isPlaying)
                        coneCollisionSFX.Play();

                    break;

                case "OppositeCar_ZUp":
                case "OppositeCar_ZDown":

                    if (!busCollisionSFX.isPlaying)
                        busCollisionSFX.Play();

                    break;

                case "Player1":
                case "Player2":

                    if (!carCollisionSFX.isPlaying)
                        carCollisionSFX.Play();

                    break;

                case "Goal":

                    if (winSFXPlayed == false)
                    {
                        if (!winSFX.isPlaying)
                        {
                            winSFX.Play();
                            winSFXPlayed = true;
                        }
                    }
                    break;
            }
        }

    }
}