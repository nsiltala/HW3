using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Collision : MonoBehaviour
{
    private int collisionCount = 0;
    private const int maxCollisions = 10;
    public Light lightSource;
    public Color hitColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color defaultColor;

    [Obsolete]
    void Start()
    {
        if (lightSource == null)
        {
            lightSource = FindObjectOfType<Light>();
        }
        if (lightSource != null)
        {
            defaultColor = lightSource.color;
        }
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "tynnyri") 
        {
            collisionCount++;
            Debug.Log("ENTER - Collision Count: " + collisionCount);
            ChangeLightColor();
            
            if (collisionCount >= maxCollisions)
            {
                Debug.Log("Maximum collisions reached. Exiting game...");
                Application.Quit(); // Closes the game
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in the Unity Editor
                #endif
            }
        }
    }
    
    void ChangeLightColor()
    {
        if (lightSource != null)
        {
            lightSource.color = hitColor;
            StartCoroutine(ResetLightColor());
        }
    }
    
    IEnumerator ResetLightColor()
    {
        yield return new WaitForSeconds(1.0f);
        if (lightSource != null)
        {
            lightSource.color = defaultColor;
        }
    }
}