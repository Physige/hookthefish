using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {
    [SerializeField] private Camera mainCamera;
    private LineRenderer line;

    void Start() {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }
    
    // creates line between line empty and cursor (tried to use hook pos instead but 
    // didnt work and i spent way too long figuring it out)
    void Update() {
        // top of line
        line.SetPosition(0, transform.position);

        // bottom of line
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            // take y position of cursor and moves end of string to it
            line.SetPosition(1, new Vector3(0, raycastHit.point.y, 0));
        }
    }
}
