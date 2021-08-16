using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCounter : MonoBehaviour {
    public static int score = 0;
    Text scoreText;

    void Start() {
        scoreText = GetComponent<Text> ();
    }

    // updates score text
    void Update() {
        scoreText.text = "Score: " + score;
    }
}
