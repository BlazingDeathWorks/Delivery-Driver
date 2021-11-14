using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames.DeliveryDriver.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] GameObject followTarget = null;

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = followTarget.transform.position + new Vector3(0, 0, -10);
        }
    }
}
