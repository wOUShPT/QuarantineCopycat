using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    private RaycastHit _hit;
    private Collider _currentCollider;
    [SerializeField]
    private float range;
    
    /*void FixedUpdate()
    {
        _currentCollider = null;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out _hit, range);
        if (!_hit.collider)
        {
            return;
        }

        _currentCollider = _hit.collider;
    }*/

    public Collider CurrentCollider => _currentCollider;
    
}
