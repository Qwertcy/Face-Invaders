using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites; //keeps track of array of sprites to cycle between them
    public float animationTime = 1.0f; //how often cycles to the next sprite
    private SpriteRenderer _spriteRenderer; //to change which sprite is being rendered
    private int _animationFrame; //keeps track which sprite is being used

    public System.Action killed;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }

    private void AnimateSprite()
    {
        _animationFrame++;
        if (_animationFrame >= animationSprites.Length)
        {
            _animationFrame = 0;
        }

        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            this.killed.Invoke();
            this.gameObject.SetActive(false);

        }
    }
}
