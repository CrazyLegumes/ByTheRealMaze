using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEnemy : BaseEnemy
{
    //lol this script is pretty useless isnt it?
    //I guess it might be useful to change the stats of the basic enemy
    void Start () {
        windup = 1;
        base.InitStats();
	}
}
