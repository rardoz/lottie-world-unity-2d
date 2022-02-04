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
        //infinitLives = true;
        // do nothing override to prevent bug
        if (Camera.main.GetComponent<CameraFollow>())
        {
            player = player ?? Camera.main.GetComponent<CameraFollow>().followObject.GetComponent<RobotController>();
            blinker = player.gameObject.GetComponent<Blinker>();
        }
    }
    public void reloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public virtual bool ShouldKill(Collider2D c2d)
    {
        bool isPlayer = c2d.CompareTag("Player");
        return isPlayer && !blinker.startBlinking;
    }

    protected void OnTriggerEntered(Collider2D c2d)
    {

        //Destroy the life if Object tagged Player comes in contact with it
        if (ShouldKill(c2d) && !infinitLives && !blinker.startBlinking)
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

    public virtual void OnTriggerEnter2D(Collider2D c2d)
    {
        OnTriggerEntered(c2d);
    }
}
