using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour {
    public static GameObject ball;
    public Material material;
    // private object currentWinner;
    public float speed = 20;
    public static TextMeshProUGUI score;
    private static int score1;
    private static int score2;
    private static string winner;
    
    // Start is called before the first frame update
    void Start() {
        Vector3 spawnPosition;
        Quaternion rotation;
        // ball = GameObject.FindWithTag("Ball");
        Debug.Log($"{ball.name}");
        if(Random.Range(1, 3) == 1) {
            spawnPosition = new Vector3(-11f, Random.Range(-5f, 5f), 0f);
            rotation = Quaternion.Euler(Random.Range(0, 11), Random.Range(-5, 5), 0);
        } else {
            spawnPosition = new Vector3(11f, 5f, 0f); // Random.Range(-5f, 5f)
            rotation = Quaternion.Euler(Random.Range(-11, 0), Random.Range(-5, 5), 0);
        }
        // spawnPosition = Vector3.zero;
        rotation = Quaternion.Euler(Vector3.left);
        ball = Instantiate(ball, spawnPosition, Quaternion.identity);
        // Rigidbody rb = ball.GetComponent<Rigidbody>();
        // Vector3 movement = new Vector3(6f, 5f, 0f);
        // rb.MovePosition(transform.position + (movement * speed * Time.deltaTime));
        // ERROR: Ball does not move
    }

    // Update is called once per frame
    void Update() {
        score.SetText(score1 + "\t" + score2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        speed += 100;
        rb.AddForce(Quaternion.Euler(0f, 0f, -60f) * Vector3.up * speed, ForceMode.Impulse);
    }

    public static void Respawn(Collider other) {
        Vector3 spawnPosition;
        if (other.CompareTag("Player1")) {
            spawnPosition = new Vector3(11f, Random.Range(-5f, 5f), 0f);
        } else {
            spawnPosition = new Vector3(-11f, Random.Range(-5f, 5f), 0f);
        }
        Instantiate(ball, spawnPosition, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(Quaternion.Euler(0f, 0f, -60f) * Vector3.up * 1000, ForceMode.Impulse);
    }

    public static void updateScore(Collider other) {
        if(other.CompareTag("Player1")) {
            score1++;
            winner = "Left";
        }

        if(other.CompareTag("Player2")) {
            score2++;
            winner = "Right";
        }
        Debug.Log($"{winner} scored!");
        Debug.Log($"{score1} - {score2}");

        if(score1 == 11 || score2 == 11) {
            if(score1 == 11) {
                winner = "Left";
            } else {
                winner = "Right";
            }
            score.SetText("Game Over, " + winner + " Paddle Wins");
            score1 = 0;
            score2 = 0;
        }
        
        Respawn(other);
    }
}