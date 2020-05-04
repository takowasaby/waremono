using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MainCamera : MonoBehaviour
{
    private static readonly float cameraFollowPlayerLerpRatio = 0.1f;
    private static readonly float cameraFollowPlayerBound = 0.01f;

    private Player player;

    [Inject]
    public void Construct(Player player)
    {
        this.player = player;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        this.FollowPlayer();
    }

    private void FollowPlayer()
    {
        var playerPosition = this.player.GetPosition();
        var cameraPosition = (Vector2)base.transform.position;

        var shouldPositionX = Mathf.Lerp(cameraPosition.x, playerPosition.x, cameraFollowPlayerLerpRatio);
        var shouldPositionY = Mathf.Lerp(cameraPosition.y, playerPosition.y, cameraFollowPlayerLerpRatio);

        if (shouldPositionY < 0f)
        {
            shouldPositionY = 0f;
        }

        var shouldPosition = new Vector2(shouldPositionX, shouldPositionY);

        if ((shouldPosition - cameraPosition).magnitude < cameraFollowPlayerBound)
        {
            return;
        }

        base.transform.position = new Vector3(shouldPosition.x, shouldPosition.y, base.transform.position.z);
    }
}
