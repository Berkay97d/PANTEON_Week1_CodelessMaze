using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotAScript : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text gameOverCanvasTimeText;
    private int time = 0;

    [SerializeField] private TMP_Text bestTimeText;
    private int bestTime = 100000;
    
    [SerializeField] private Canvas gameOverCanvas;
    private bool isGameOver;

    private Vector3 startPos;


    [SerializeField] private Transform parent;
    [SerializeField] private Transform grandParent;
    
    

    private void Start()
    {
        startPos = transform.position;
        StartCoroutine(Timer());
    }

    private void Update()
    {
        HandleUI();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (time < bestTime)
        {
            bestTime = time;
        }
        gameOverCanvas.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void RestartGame()
    {
        transform.position = startPos;
        time = 0;
        isGameOver = false;
        gameOverCanvas.gameObject.SetActive(false);

        var vec = new Vector3(0, 0, 0);
        parent.localRotation = Quaternion.Euler(vec);
        grandParent.rotation = Quaternion.Euler(vec);
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            if (!isGameOver)
            {
                time++;
            }
        }
        
    }

    private void HandleUI()
    {
        timeText.text = "Time: " + time;
        gameOverCanvasTimeText.text = "Time: " + time;
        bestTimeText.text = "Best Time: " + bestTime;
    }
}
