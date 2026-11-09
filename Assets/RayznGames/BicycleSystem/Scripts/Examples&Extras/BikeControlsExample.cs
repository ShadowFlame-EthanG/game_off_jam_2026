using rayzngames;
using UnityEngine;
using UnityEngine.InputSystem;

namespace rayzngames
{        
    public class BikeControlsExample : MonoBehaviour
    {
        BicycleVehicle bicycle;
        public bool controllingBike;
        InputAction move;
        InputAction brake;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            bicycle = GetComponent<BicycleVehicle>();
            if (InputSystem.actions) {
                move = InputSystem.actions.FindAction("Player/Move");
                brake = InputSystem.actions.FindAction("Player/Brake");
            }
        }
        // Update is called once per frame
        void Update()
        {
            Vector2 moveValue = move.ReadValue<Vector2>();
            bicycle.verticalInput = moveValue[1];
            bicycle.horizontalInput = moveValue[0];
            BrakingInput();

            //Extending functionality 
            bicycle.InControl(controllingBike);

            if (controllingBike)
            {
                //Constrains the Z rotation of the bike, when onground, and releases it when airborne.
                bicycle.ConstrainRotation(bicycle.OnGround());
            }
            else
            {
                bicycle.ConstrainRotation(false);
            }

            /*
            //Detach controls
            if (bicycle.OnGround() == false) { controllingBike = false; }

            //Landing Controls (Land Pressing E)
            if (Input.GetKey(KeyCode.E)) { controllingBike = true; }
            bicycle.InControl(controllingBike);   
            */
        }
        void BrakingInput()
        {
            if (brake.IsPressed())
            {
                bicycle.braking = true;
            }
            else
            {
                bicycle.braking = false;
            }

        }
    }
}
