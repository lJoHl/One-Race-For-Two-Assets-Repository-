using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class UIAndRestart : MonoBehaviour
    {
        // activation variables
        private int winner = 0;

        private bool gameOver = false;


        // Freeze time at game start
        private void Start()
        {
            Time.timeScale = 0;
        }


        private void Update()
        {
            // calls restar method
            Restart();
        }



        //___________________________________________UI Methods___________________________________________
        // Sets the position and content of the texts
        private void OnGUI()
        {
            // shows the game title and the instruction to start the game, while time is frozen
            if (Time.timeScale == 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 55, 80, 110, 20), "One Race For Two");
                GUI.Label(new Rect(Screen.width / 2 - 65, 100, 130, 20), "Press SPACE to Start");
            }

            // unfreeze time by pressing space key
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
            }

            if (Time.timeScale == 1)
            { 
                if (winner == 0)
                {
                    // show player controls when pressing "E" or "-"
                    if (Input.GetKey(KeyCode.E) | Input.GetKey(KeyCode.Minus))
                    {
                        GUI.Label(new Rect(Screen.width / 2 - 20, 67, 40, 20), "Move");
                        GUI.Label(new Rect(Screen.width / 2 - 70, 80, 140, 20), "P1: WASD / P2: Arrows");
                        GUI.Label(new Rect(Screen.width / 2 - 40, 101, 80, 20), "Change View");
                        GUI.Label(new Rect(Screen.width / 2 - 65, 114, 130, 20), "P1: Q / P2: Right Ctrl");
                        GUI.Label(new Rect(Screen.width / 2 - 30, 135, 60, 20), "Respawn");
                        GUI.Label(new Rect(Screen.width / 2 - 65, 148, 130, 20), "P1: R / P2: Right Shift");
                    }
                    // shows the instructions to show the player controls, as long as "E" or "-" is not being pressed
                    else
                    {
                        GUI.Label(new Rect(Screen.width / 2 - 45, 0, 90, 20), "Show Controls ");
                        GUI.Label(new Rect(Screen.width / 2 - 20, 13, 40, 20), "E or -");
                    }
                }
                // when there is a winner, the final messages are displayed, showing the winning player based on the value of the variable winner
                else
                {
                    if (winner == 1)
                    {
                        GUI.Label(new Rect(Screen.width / 2 - 45, 0, 90, 20), "Player 1 Wins");
                    }
                    else if (winner == 2)
                    {
                        GUI.Label(new Rect(Screen.width / 2 - 45, 0, 90, 20), "Player 2 Wins");
                    }

                    GUI.Label(new Rect(Screen.width / 2 - 85, 30, 170, 20), "THANK YOU FOR PLAYING");
                    GUI.Label(new Rect(Screen.width / 2 - 75, 55, 150, 20), "R / Right Shift to Restart");
                }
            }
        }


        // Marks the end of the game at the moment a player collides with the goal
        private void OnCollisionEnter(Collision collision)
        {
            // when there is a winner, the final messages are displayed, showing the winning player based on the value of the variable winner
            if (gameOver == false)
            {
                if (collision.gameObject.name == "Player1")
                {
                    winner = 1;
                    gameOver = true;
                }
                else if (collision.gameObject.name == "Player2")
                {
                    winner = 2;
                    gameOver = true;
                }
            }
        }


        //___________________________________________Restart Method___________________________________________
        //Restart method, allows players to play again, only if the game has already finished
        private void Restart()
        {
            if (gameOver == true)
            {
                // pressing "R" or "LeftShift" restarts the game
                if (Input.GetKeyDown(KeyCode.R) | Input.GetKeyDown(KeyCode.RightShift))
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}