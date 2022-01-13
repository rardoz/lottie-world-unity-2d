using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : Life
{
    public bool shouldDestroy = true;

    public Blinker blinker;

    public virtual void onDeadlyTriggered(Collider2D c2d)
    {

    }

    void Awake()
    {
        // do nothing override to prevent bug
        if (Camera.main.GetComponent<CameraFollow>())
        {
            player = player ?? Camera.main.GetComponent<CameraFollow>().followObject;
            blinker = player.gameObject.GetComponent<Blinker>();
        }
    }
    public void reloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    protected void OnTriggerEntered(Collider2D c2d)
    {
        bool isPlayer = c2d.CompareTag("Player");

        //Destroy the life if Object tagged Player comes in contact with it
        if (isPlayer && !blinker.startBlinking)
        {
            blinker.startBlinking = true;
            //Destroy life
            if (shouldDestroy)
            {
                Destroy(gameObject);
            }
            //Add life to counter
            totalLives--;
            onDeadlyTriggered(c2d);
        }
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        OnTriggerEntered(c2d);
    }
}
