using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static Controls controls;


    public static void Init(Player myPlayer)
    {
        controls = new Controls();

        controls.Game.Movement.performed += ctx =>
        {
            myPlayer.setMovementDirection(ctx.ReadValue<Vector2>());

        };

        controls.Game.Jump.started += ctx =>
        {
            myPlayer.jump();
        };



        controls.Enable();


    }
}
