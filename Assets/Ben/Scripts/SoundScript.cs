using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource playerSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseGame.paused)
        {
            playerSound.Stop();
        }
        else
        {
            if (playerMovement.instance.rb.velocity != Vector2.zero && playerSound.isPlaying == false)
            {
                playerSound.Play();
            }
            else if (playerMovement.instance.rb.velocity == Vector2.zero)
            {
                playerSound.Stop();
            }
        }
    }
}
