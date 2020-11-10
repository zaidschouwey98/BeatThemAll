using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Character
{
    // Start is called before the first frame update
    void Start()
    {
        dmg = 10;
        hp = 100;
        attackspeed = 0.65f;
        maxHp = 100;
    }
}
