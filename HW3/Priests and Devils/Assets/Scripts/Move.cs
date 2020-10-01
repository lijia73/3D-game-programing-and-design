using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    private float moveSpeed = 20;
    private int movingState;  // 0->not moving, 1->moving to middle, 2->moving to target
    private Vector3 middle;
    private Vector3 target;

    void Update()
    {
        if (movingState == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, middle, moveSpeed * Time.deltaTime);
            if (transform.position == middle)
            {
                movingState = 2;
            }
        }
        else if (movingState == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
            if (transform.position == target)
            {
                movingState = 0;
            }
        }
        SSDirector.getInstance().moving = false;
    }
    public void setDestination(Vector3 t)
    {
        SSDirector.getInstance().moving = true;
        target = t;
        middle = t;
        if (t.y == transform.position.y)
        {   // boat moving
            movingState = 2;
        }
        else if (t.y < transform.position.y)
        {   // character from coast to bank
            middle.y = transform.position.y;
        }
        else
        {                               // character from boat to bank
            middle.x = transform.position.x;
        }
        movingState = 1;
    }

    public void reset()
    {
        movingState = 0;
    }
}