using System;
using UnityEngine;

namespace Scripts
{
    public class BusActivation : MonoBehaviour
    {
        // object variable
        private DisappearObjects dOInBA = new DisappearObjects();

        // activation variables
        private bool busActive = true;

        // speed variable
        private int busSpeed = 10;


        // Calls the "Player1" and "Player2" properties of the "DisappearObjects" script and assigns a value to them
        private void Start()
        {
            dOInBA.Player1 = GameObject.Find("Player1");
            dOInBA.Player2 = GameObject.Find("Player2");
        }

        // Moves the bus forward when you get close to it, based on the player's position and the object the script is on
        private void Update()
        {
            if (gameObject.name == "OppositeCar_ZDown")
                if (dOInBA.Player1.transform.position.x > 212 | dOInBA.Player2.transform.position.x > 212)
                    busActive = true;
                else
                    busActive = false;

            if (busActive == true)
                if (Math.Abs(dOInBA.Player1.transform.position.z - transform.position.z) <= 50 | Math.Abs(dOInBA.Player2.transform.position.z - transform.position.z) <= 50)
                    transform.Translate(Vector3.forward * Time.deltaTime * busSpeed);
        }
    }
}
