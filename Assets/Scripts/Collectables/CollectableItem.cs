using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Collectable Attributes;
    [SerializeField] private GameObject CollectedEffect;

    private CircleCollider2D _collider;
    private SpriteRenderer _sprite;

    private void Start() {
        _collider = GetComponent<CircleCollider2D>();
        _sprite = GetComponent<SpriteRenderer>();
    }  

    private void Collected()
    {
        _collider.enabled = false;
        _sprite.enabled = false;

        CollectedEffect.SetActive(true);

        GameManager.Instance.UpdateScore(Attributes.Score);

        Destroy(gameObject, 1);
    }

    private void DisableItem()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Collected();    
    }
}
