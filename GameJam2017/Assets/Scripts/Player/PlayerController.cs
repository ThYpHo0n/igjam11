using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UberControlledObj {

    public override void Die() {
        //TBD
    }

    public override void Spawn() {
        //TBD
    }

    // Update is called once per frame
    public override void Update () {
        this.Move(Input.GetAxis("Horizontal"));
    }
}
