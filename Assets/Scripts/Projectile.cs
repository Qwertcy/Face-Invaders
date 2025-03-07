using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    public System.Action destroyed;

    public void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.destroyed != null)
        {
            this.destroyed.Invoke();                               
        }
        Destroy(this.gameObject);
    }
}
