using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Name: Michael Parizeau
/// Date: 12/7/24
/// Description: Allows the player to look around smoothly
/// </summary>

public class MouseLook : MonoBehaviour
{
    // initializing vector variables
    Vector2 mouseLook;
    Vector2 smoothV;
    Vector2 md;
    // initializing variables for mouse movement
    public float sensitivity = 20.0f;
    public float smoothing = 0.5f;
    // allows reference to parent object (player)
    GameObject character;

    void Start()
    {
        // instantiates "character" as the parent object (player)
        character = this.transform.parent.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        // dynamic variable for vector scaling
        float sScale = sensitivity * smoothing;

        // initializing vectors of inputs for camera movement
        md = Vector2.Scale(new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")), new Vector2(sScale, sScale));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, smoothing);
        // applies the smoothing to the mouse inputs
        mouseLook += smoothV;
        // limits camera y-axis movements to 90 degrees, so player can't look down
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);
        // moves the camera
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        // rotates the player, so the camera's and player's "forward" are always the same
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
