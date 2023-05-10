using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LiquidBase : MonoBehaviour
{
    public LayerMask affectedLayer;
    public PlayerAffection playerAffection = PlayerAffection.None;

    public AudioClip audioClip;
    private float volume = .3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(affectedLayer.value);
        if (1 << collision.gameObject.layer == affectedLayer.value)//using bitwise operator the layers are compared
        {
            print("Enter");

            if ((int)playerAffection == -1)
            {
                collision.gameObject.GetComponent<PlayerManager>().Kill();
            }
            else if (collision.gameObject.tag != playerAffection.ToString())
            {
                collision.gameObject.GetComponent<PlayerManager>().Kill();
            }
            else
            {
                SoundManager.instance.PlaySound(audioClip, volume);
            }
        }
    }
}

[Flags]//Flags used for multiple tag choice
public enum PlayerAffection
{
    None = 0,
    Player1 = 1,
    Player2 = 2
}
