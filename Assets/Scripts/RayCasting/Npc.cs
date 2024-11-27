using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private float distance = 5.0f;  // Default distance for raycasting

    private bool _showExclamationMark = true;
    private bool _showTutorial = false;

    private void Start() 
    {
        Debug.Log("NPC raycast started");
    }

    private void Update()
    {
        // Cast a ray to the right from the NPC's position
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.right, distance);
        if (hitInfo.collider != null)
        {
            Debug.Log("Ray hit: " + hitInfo.collider.name + ", Tag: " + hitInfo.collider.tag);
            Debug.Log("Hit position: " + hitInfo.point);
        }
        else
        {
            Debug.Log("Ray did not hit anything.");
        }


        // Draw the ray in the Scene view for debugging
        Debug.DrawRay(transform.position, Vector2.right * distance, Color.red);

        // Check if the ray hits something and is not currently showing the tutorial
        if (!_showTutorial && hitInfo.collider != null && hitInfo.collider.CompareTag("Player"))
        {
            ShowTutorial();
        }

        // Check if the ray does not hit anything and the tutorial is currently showing
        if (_showTutorial && (hitInfo.collider == null || !hitInfo.collider.CompareTag("Player")))
        {
            UnShowTutorial();
        }
    }

    private void ShowTutorial()
    {
        _showTutorial = true;
        _showExclamationMark = false;
        Debug.Log("Tutorial shown: _showTutorial = true, _showExclamationMark = false");
    }

    private void UnShowTutorial()
    {
        _showTutorial = false;
        _showExclamationMark = true;
        Debug.Log("Tutorial hidden: _showTutorial = false, _showExclamationMark = true");
    }
}
