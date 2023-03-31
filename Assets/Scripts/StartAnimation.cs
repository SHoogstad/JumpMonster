using System.Collections;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    private bool played;
    [SerializeField] public Animator chest;
    [SerializeField] public SpriteRenderer coinRenderer;
    [SerializeField] public BoxCollider2D boxColliderCoin;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (played) return;

        chest.enabled = true;
        played = true;
        StartCoroutine(SpawnCoin(.75f));
        
    }
    
    private IEnumerator SpawnCoin(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        boxColliderCoin.isTrigger = true;
        var color = coinRenderer.GetComponent<SpriteRenderer>().color;
        coinRenderer.color = new Color(color.r, color.g, color.b, 1f);
    }
}

    
