using UnityEngine;
using Color = UnityEngine.Color;

public class SeeThrough : MonoBehaviour
{
        [SerializeField] private SpriteRenderer wall;
        [SerializeField] private Transform size;

        private void OnTriggerEnter2D(Collider2D col)
        {
                var color = wall.GetComponent<SpriteRenderer>().color;
                wall.GetComponent<SpriteRenderer>().color = new Color(color.r,color.g,color.b,0.7f);

                size.localScale = new Vector3(0.125f, 0.125f);
        }

        private void OnTriggerExit2D(Collider2D otherCollider)
        {
                var color = wall.GetComponent<SpriteRenderer>().color;
                wall.GetComponent<SpriteRenderer>().color = new Color(color.r,color.g,color.b,1f);
                
                size.localScale = new Vector3(0.25f, 0.25f);

        }
}
