using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.UIElements;

public class StripScroller : MonoBehaviour
{

    public float scrollSpeed = 1f;
    public float tileSizeZ = 200f;

    private Image Background;
    private Vector2 savedOffset;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        Background = GetComponent<Image>();
        savedOffset = Background.position.position;
    }

    void Update()
    {
        float x = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ * 4f);
        x = x / tileSizeZ;
        x = Mathf.Floor(x);
        x = x / 4;
        Vector2 offset = new Vector2(x, savedOffset.y);
        Vector2.MoveTowards(savedOffset, offset, 100f);
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.back * newPosition;
    }

    void OnDisable()
    {
        Vector2.MoveTowards(startPosition, savedOffset, 100f);
    }
}