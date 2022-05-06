using UnityEngine;

namespace Scripts
{
    public class RelatedToSpeedAndMovementInput : MonoBehaviour
    {
        // activation variables
        private bool respawned = false;

        // input variables
        private float horizontalInput;
        private float verticalInput;

        // speed variables
        private float speed = 20;
        private float rotationSpeed = 50;

        // audio variables
        public AudioSource player1_CarEngineMovingForward;
        public AudioSource player1_CarEngineResting;
        public AudioSource player1_CarEngineReversing;

        public AudioSource player2_CarEngineMovingForward;
        public AudioSource player2_CarEngineResting;
        public AudioSource player2_CarEngineReversing;


        // Prevent car engine audios from playing when starting the game
        private void Start()
        {
            player1_CarEngineMovingForward.Stop();
            player1_CarEngineResting.Stop();
            player1_CarEngineReversing.Stop();

            player2_CarEngineMovingForward.Stop();
            player2_CarEngineResting.Stop();
            player2_CarEngineReversing.Stop();
        }


        private void Update()
        {
            //Calls movement input method
            MovementInput();

            //Calls respawn method
            if (Time.timeScale == 1)
                Respawn();

            //Calls player engine sfx method
            PlayerEngineSFX();
        }



        //____________________________________________Collisions Method____________________________________________
        // Modifies the behavior of the player when colliding with a certain object
        private void OnCollisionStay(Collision collision)
        {
            switch (collision.gameObject.name)
            {
                case "Crate_01_ZUp":
                case "Crate_01_XRight":
                case "Crate_01_ZDown":
                    speed = 13.2f;
                    break;

                case "Prop_Cone_01_ZUp":
                case "Prop_Cone_01_ZDown":
                    speed = 16.5f;
                    break;

                case "OppositeCar_ZUp":
                    if (verticalInput > 0)
                        verticalInput -= 2;
                    else
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                    break;


                case "OppositeCar_ZDown":
                    if (verticalInput > 0)
                        verticalInput -= 2;
                    else
                        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                    break;

                case "respawnCollisionStart":
                    transform.position = new Vector3(0, 10, 0);
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    break;

                case "respawnCollisionCorner1":
                    transform.position = new Vector3(0, 10, 396);
                    transform.eulerAngles = new Vector3(0, 90, 0);
                    break;

                case "respawnCollisionCorner2":
                    transform.position = new Vector3(219, 10, 396);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    break;

                case "respawnCollisionEnd":
                    transform.position = new Vector3(219, 10, -35);
                    transform.eulerAngles = new Vector3(0, 180, 0);
                    break;

                default:
                    speed = 20;
                    break;
            }
        }


        //________________________________________Movement Input Method__________________________________________
        // Allows the player to move
        private void MovementInput()
        {
            // set the horizontal and vertical input depending on the player the script is on
            if (gameObject.name == "Player1")
            {
                horizontalInput = Input.GetAxis("Horizontal Player 1");
                verticalInput = Input.GetAxis("Vertical Player 1");
            }
            else if (gameObject.name == "Player2")
            {
                horizontalInput = Input.GetAxis("Horizontal Player 2");
                verticalInput = Input.GetAxis("Vertical Player 2");
            }


            // allows the player to move forward and backward
            if (verticalInput > 0)
                transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            else if (verticalInput < 0)
                transform.Translate(Vector3.forward * Time.deltaTime * (speed * .5f) * verticalInput);

            // allows the player to rotate when moving forward or backward
            if (verticalInput > 0)
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
            else if (verticalInput < 0)
                transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * -horizontalInput);
        }


        //________________________________________Respawn Method__________________________________________
        // Allows to respawn the player, located in the center of the path based on the position in which he is
        private void Respawn()
        {
            // assigns the value of true to the respawned variable if the respawn button is pressed
            if ((gameObject.name == "Player1") ? Input.GetKeyDown(KeyCode.R) : Input.GetKeyDown(KeyCode.RightShift))
                respawned = true;
            else
                respawned = false;

            // calculate where the play should respawn when falling or pressing the respawn button
            if (transform.position.y < 1) // prevents the player from respawning many times in a row
            {
                if (transform.position.x <= 100 & transform.position.z < 389)
                {
                    if (respawned == true | (transform.position.y < -20 & (transform.position.x < -1 | transform.position.x > 1)))
                    {
                        transform.position = new Vector3(0, 10, transform.position.z);
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                }

                if (transform.position.x >= 13 & transform.position.x < 212 & transform.position.z >= 344)
                {
                    if (respawned == true | (transform.position.y < -20 & (transform.position.z < 395 | transform.position.z > 397)))
                    {
                        transform.position = new Vector3(transform.position.x, 10, 396);
                        transform.eulerAngles = new Vector3(0, 90, 0);
                    }

                }

                if (transform.position.x >= 101 & transform.position.z < 389)
                {
                    if (respawned == true | (transform.position.y < -20 & (transform.position.x < 218 | transform.position.x > 220)))
                    {
                        transform.position = new Vector3(219, 10, transform.position.z);
                        transform.eulerAngles = new Vector3(0, 180, 0);
                    }

                }
            }

            // prevent player from moving while respawning
            if (transform.position.y >= 5)
                speed = 0;
        }


        //________________________________________Player Engine SFX Method__________________________________________
        // Activates the sounds of the car engine depending on whether it is; moving forward, backward or resting
        private void PlayerEngineSFX()
        {
            // plays the audio whenever the game is unfrozen and depending on the player the script is on
            if (Time.timeScale == 1)
            {
                if (gameObject.name == "Player1")
                {
                    if (verticalInput > 0)
                    {
                        if (!player1_CarEngineMovingForward.isPlaying)
                            player1_CarEngineMovingForward.Play();
                    }
                    else
                        player1_CarEngineMovingForward.Stop();

                    if (verticalInput < 0)
                    {
                        if (!player1_CarEngineReversing.isPlaying)
                            player1_CarEngineReversing.Play();
                    }
                    else
                        player1_CarEngineReversing.Stop();

                    if (verticalInput == 0)
                    {
                        if (!player1_CarEngineResting.isPlaying)
                            player1_CarEngineResting.Play();
                    }
                    else
                        player1_CarEngineResting.Stop();
                }
                else if (gameObject.name == "Player2")
                {
                    if (verticalInput > 0)
                    {
                        if (!player2_CarEngineMovingForward.isPlaying)
                            player2_CarEngineMovingForward.Play();
                    }
                    else
                        player2_CarEngineMovingForward.Stop();

                    if (verticalInput < 0)
                    {
                        if (!player2_CarEngineReversing.isPlaying)
                            player2_CarEngineReversing.Play();
                    }
                    else
                        player2_CarEngineReversing.Stop();

                    if (verticalInput == 0)
                    {
                        if (!player2_CarEngineResting.isPlaying)
                            player2_CarEngineResting.Play();
                    }
                    else
                        player2_CarEngineResting.Stop();
                }
            }
        }

    }
}