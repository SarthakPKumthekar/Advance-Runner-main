using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject obstacle;
    public Transform spawnPoint;

    public TextMeshProUGUI scoreText;
    public GameObject playButton;
    public GameObject player;
    public GameObject road;
    int score = 0;

    public AudioClip backgroundMusic; // Reference to background music clip

    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (backgroundMusic != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Background music clip not assigned to GameManager!");
        }
    }

    void Update()
    {
        // ... existing Update logic, if any
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        road.SetActive(true);
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacles");
        InvokeRepeating("ScoreUp", 2f, 1.5f);
    }
}
