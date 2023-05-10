using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FalseWall : MonoBehaviour
{
    public LayerMask layerMask;
    public AudioClip audioClip;
    public bool IsFound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(1 << collision.gameObject.layer == layerMask.value)
        {
            if (!IsFound)
            {
                SoundManager.instance.PlaySound(audioClip, 1f);
                IsFound = true;
            }
            this.gameObject.GetComponent<TilemapRenderer>().sortingLayerName = "-2";
        }
    }
}
