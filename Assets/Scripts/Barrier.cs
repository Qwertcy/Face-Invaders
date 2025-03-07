using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Tooltip("Number of hits before the barrier is fully destroyed.")]
    public int maxHits = 3;

    private int currentHits = 0;

    //original local scale
    private Vector3 initialScale;

    private void Start()
    {
        // record scale of barrier at start
        initialScale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile"))
        {
            Destroy(other.gameObject);
            currentHits++;

            if (currentHits >= maxHits)
            {
                gameObject.SetActive(false);
            }
            else
            {
                ShrinkBarrier();
            }
        }
        else if (other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void ShrinkBarrier()
    {
        // Fraction of how 'damaged' the barrier is (0 = no damage, 1 = fully destroyed).
        float fractionDamaged = (float)currentHits / (float)maxHits;

        float newScaleY = 1.0f - fractionDamaged;

        // applying new scale. only y is reduced
        Vector3 scale = new Vector3(initialScale.x, initialScale.y * newScaleY, initialScale.z);
        transform.localScale = scale;
    }
}
