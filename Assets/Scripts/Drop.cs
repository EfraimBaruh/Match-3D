using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class Drop : MonoBehaviour
{
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public virtual void OnSelection() { }
}
