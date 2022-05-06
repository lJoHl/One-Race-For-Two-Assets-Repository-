using UnityEngine;

namespace Scripts
{
    public class PlayerChangeView : MonoBehaviour
    {
        // camera variables
        private GameObject camera;

        private Vector3 offset;
        private Vector3 offsetRotate;

        private int changeCameraId = 1;


        // Sets the value of the camera variable depending on which player the script is on
        private void Start()
        {
            if (gameObject.name == "Player1")
            {
                camera = GameObject.Find("Main Camera");
            }
            else if (gameObject.name == "Player2")
            {
                camera = GameObject.Find("Second Camera");
            }
        }


        // Change the player's point of view
        private void LateUpdate()
        {
            // change the camera Id by pressing the letter "Q" in the player 1 case, or the letter "RightCtrl" in the player 2 case
            if ((gameObject.name == "Player1") ? Input.GetKeyDown(KeyCode.Q) : Input.GetKeyDown(KeyCode.RightControl))
                if (changeCameraId == 2)
                    changeCameraId = 1;
                else
                    changeCameraId++;

            // sets the values for the camera position and rotation depending on the value of the changeCameraId
            switch (changeCameraId)
            {
                case 1:
                    offset.y = 6.9f;

                    offsetRotate.x = 24.248f;

                    if (transform.position.z <= 389 & transform.position.x <= 13)
                    {
                        offset.z = -7.8f;
                        offset.x = 0;

                        offsetRotate.y = 0;
                    }
                    else if (transform.position.z >= 389 & transform.position.x >= 13 & transform.position.x < 212)
                    {
                        offset.z = 0;
                        offset.x = -7.8f;

                        offsetRotate.y = 90;
                    }
                    else if (transform.position.z <= 389 & transform.position.x >= 212)
                    {
                        offset.z = 7.8f;
                        offset.x = 0;

                        offsetRotate.y = 180;
                    }

                    camera.transform.eulerAngles = offsetRotate;
                    break;

                case 2:
                    float rotationY = transform.eulerAngles.y;
                    rotationY = (rotationY > 180) ? rotationY - 360 : rotationY;

                    offset.y = 1.96f;

                    if (rotationY > -45 & rotationY < 45)
                    {
                        offset.z = 0.41f;
                        offset.x = 0;
                    }
                    else if (rotationY > 45 & rotationY < 135)
                    {
                        offset.x = 0.41f;
                        offset.z = 0;
                    }
                    else if (rotationY > -135 & rotationY < -45)
                    {
                        offset.x = -0.41f;
                        offset.z = 0;
                    }
                    else if (rotationY > 135 | rotationY < -135)
                    {
                        offset.z = -0.41f;
                        offset.x = 0;
                    }

                    camera.transform.eulerAngles = transform.eulerAngles;
                    break;

                default:
                    break;
            }

            camera.transform.position = transform.position + offset;
        }
    }
}