using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    private const int HITS = 3;
    private const int BASIC_POINT = 1;
    
    public AudioClip audioClip;
    
    [Tooltip("Hits before destroy")]
    public int hits;
    [Header("Points after destroy")]
    public int points;
    
    [Header("Special props")]
    public bool invisible;
    public bool solid;

    public Sprite[] visualDamageSprites;
    public SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        hits = hits > 0 ? hits : HITS;
        points = points > 0 ? points : BASIC_POINT;
        
        if (invisible)
        {
            spriteRenderer.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (solid)
        {
            return;
        }
        
        if (invisible)
        {
            spriteRenderer.enabled = true;
            invisible = false;
            return;
        }
        
        hits--;
        
        if(hits <= 0)
        {
            DestroyBlock();
            return;
        }

        if (visualDamageSprites.Length >= hits)
        {
            spriteRenderer.sprite = visualDamageSprites[visualDamageSprites.Length - hits];
        }
    }

    private void DestroyBlock()
    {
        Debug.Log("destroy on collision");
        AudioManager.Instance.PlayOnShot(audioClip);
        HUDManager.Instance.UpdateScore(points);
        Destroy(gameObject);
    }
}
