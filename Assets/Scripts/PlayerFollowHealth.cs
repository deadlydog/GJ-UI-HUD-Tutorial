using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowHealth : MonoBehaviour
{
    public Camera cam;
    public RectTransform canvasRect;
    public RectTransform itemRect;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 viewPosition = cam.WorldToScreenPoint(playerTransform.position);
        
        // TODO: Do proper transformation to have health stay over player. 

        itemRect.anchoredPosition = viewPosition;
    }
}
