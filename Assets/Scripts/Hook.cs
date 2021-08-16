using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hook : MonoBehaviour {
    [SerializeField] private Camera mainCamera;

    private int worms = 3;
    private GameObject fish;

    private bool isHooked = false;

    // shoots out a raycast from the camera to the cursor, gets the point
    void Update() {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            // take y position of cursor and moves the hook's y position
            transform.position = new Vector3(0, raycastHit.point.y, 0);
            //Debug.Log(raycastHit.point);
        }
        
        // checks if fish is hooked, if so, make fish follow hook
        if (isHooked) {
            fish.transform.position = transform.position;
        }

        // when fish pulled to surface, reset hook, increase score
        if (isHooked && transform.position.y >= 3.8) {
            Destroy(fish);
            isHooked = false;
            GameCounter.score++;
        }
    }

    // detects collision
    void OnTriggerEnter(Collider col) {
        // only runs if hook collides with fish and there is not already another fish on hook
        if (col.tag == "Fish" && !isHooked) {
            fish = col.gameObject;

            // sets fishes velocity to zero
            fish.GetComponent<Rigidbody>().velocity = Vector3.zero;

            // rotates fish
            fish.transform.Rotate(0,90,0);

            // runs update that makes fish follow hook
            isHooked = true;
        }

        // runs if tag is shark
        if (col.tag == "Shark") {
            // shark eats fish and worm
            if (isHooked) {
                isHooked = false;
                Destroy(fish);
                worms--;

                // TEMP FOR DEMO
                GameCounter.score--;
            }else {
                worms--;
                // TEMP FOR DEMO
                GameCounter.score--;
            }
        }
    }
}
