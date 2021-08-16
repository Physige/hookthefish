using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HookMenu : MonoBehaviour {
    [SerializeField] private Camera mainCamera;

    private bool isHooked = false;
    private bool isHighlighted = false;
    // shoots out a raycast from the camera to the cursor, gets the point
    void Update() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            // take y position of cursor and moves the hook's y position
            transform.position = new Vector3(0, raycastHit.point.y, 0);
            //Debug.Log(raycastHit.point);
        }
        
        // checks if play button is clicked while highlighted
        if (isHighlighted) {
            if (Input.GetMouseButtonDown(0)) {
                SceneManager.LoadScene("Hook the Fish");
            }
        }
    }

    // detects collision
    void OnTriggerEnter(Collider col) {
        // detects play button
        if (col.name == "Play") {
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;
            isHighlighted = true;
        }
    }

    void OnTriggerExit(Collider col) {
        // detects play button
        if (col.name == "Play") {
            col.gameObject.GetComponent<Renderer>().material.color = Color.black;
            isHighlighted = false;
        }
    }
}