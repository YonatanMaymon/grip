using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinTool : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float RotationSpeedMultiplayer;
    [SerializeField] private float friction;
    [SerializeField] private float maxSpeed;
    [SerializeField] AudioManager audioManager;
    [SerializeField] private float soundPitchMultyplayer;
    string soundName = "SwingWeapon";
    float rotation;
    [HideInInspector]  public float rotationStrangth;
    Vector3 exis = new Vector3(0, 0, 1);

    //---------------------------------------------------------------------------------------------------------------------------------

    void Update()
    {
        // making smoth rotation
        rotation += (-Input.GetAxis("Mouse X") * RotationSpeedMultiplayer);

        // limmiting the rotation speed too max speed
        if (Mathf.Abs(rotation) >= maxSpeed)
        {
            if (rotation < 0)
            {
                rotation = -maxSpeed;
            }
            else
            {
                rotation = maxSpeed;
            }
        }

        // getting the rotation strangth in a scale from 0 to 1
        rotationStrangth =  Mathf.Abs(rotation) / maxSpeed;
    }

    //---------------------------------------------------------------------------------------------------------------------------------

    private void FixedUpdate()
    {
        // avoiding bugs by setting rotation to 0 in the first sec of the game
        if (Time.fixedTime < 1)
        {
            rotation = 0;
        }

        // making the phisical rottion to heppen
        if (Mathf.Abs(rotation)>1)
        {
            transform.RotateAround(target.position, exis, rotation * Time.deltaTime);
            audioManager.Pitch(soundName , 0.5f * rotationStrangth + soundPitchMultyplayer);
            rotation = rotation / friction;
        }

        // tool sound effects
        if (rotationStrangth > 0.05)
        {
            if (! audioManager.IsPlaying(soundName))
            {
                audioManager.Play(soundName, true);
            }
            
        }
        else
        {
            audioManager.Play(soundName, false);
        }

        // making sure the tool allways facing the player
        Vector3 targ = target.position;
        targ.x = targ.x - transform.position.x;
        targ.y = targ.y - transform.position.y;
        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90));
    }
}
