using UnityEngine;

namespace Scripts
{
    public class DisappearObjects : MonoBehaviour
    {
        // Assigns a value to the "Player1" and "Player2" properties
        private void Start()
        {
            Player1 = GameObject.Find("Player1");
            Player2 = GameObject.Find("Player2");
        }


        // Makes objects disappear after passing each other and moving away based on player position
        private void Update()
        {
            switch (gameObject.name)
            {
                case "Crate_01_ZUp":
                case "Prop_Cone_01_ZUp":
                case "OppositeCar_ZUp":
                    if (gameObject.name == "Crate_01_ZUp") // it is enough for a single player to pass the boxes so that they disappear
                    {
                        if (Player1.transform.position.z - transform.position.z > 100 | Player2.transform.position.z - transform.position.z > 100)
                            gameObject.SetActive(false);
                    }
                    else
                    {
                        if (Player1.transform.position.z - transform.position.z > 100 & Player2.transform.position.z - transform.position.z > 100)
                            gameObject.SetActive(false);
                    }

                    if (Player1.transform.position.x > 13 & Player2.transform.position.x > 13)
                        gameObject.SetActive(false);
                    break;

                case "Crate_01_XRight":
                    if (Player1.transform.position.x - transform.position.x > 50 | Player2.transform.position.x - transform.position.x > 50)
                        gameObject.SetActive(false);

                    if (Player1.transform.position.x > 212 & Player2.transform.position.x > 212)
                        gameObject.SetActive(false);
                    break;

                case "Crate_01_ZDown":
                case "Prop_Cone_01_ZDown":
                case "OppositeCar_ZDown":
                    if (Player1.transform.position.x > 212 & Player2.transform.position.x > 212)
                    {
                        if (gameObject.name == "Crate_01_ZDown")
                        {
                            if (Player1.transform.position.z - transform.position.z < -100 | Player2.transform.position.z - transform.position.z < -100 )
                                gameObject.SetActive(false);
                        }
                        else
                        {
                            if (Player1.transform.position.z - transform.position.z < -100 & Player2.transform.position.z - transform.position.z < -100)
                                gameObject.SetActive(false);
                        }

                        if (Player1.transform.position.z < 0 & Player2.transform.position.z < 0)
                            gameObject.SetActive(false);
                    }
                    break;
            }

            // makes objects disappear if they fall out of the road
            if (transform.position.y < -20)
                gameObject.SetActive(false);
        }


        // Creates the properties "Player1" and "Player2"
        public GameObject Player1 { get; set; }
        public GameObject Player2 { get; set; }
    }
}
