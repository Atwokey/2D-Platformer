using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHandling : MonoBehaviour
{
    private readonly float _distanceToCheck = 0.009f;

    public bool Grounded {get; private set;}

    private void Update()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, _distanceToCheck))
            Grounded = true;
        else
            Grounded = false;    
    }

    public void Jumped()
    {
        Grounded = false;
    }
}
