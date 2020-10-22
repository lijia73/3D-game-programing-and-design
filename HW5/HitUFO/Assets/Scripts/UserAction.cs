using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UserAction
{
    void hit(Vector3 pos);
    void restart();
}