using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public float gravity;
    public float drag;
    public float angularDrag;

    public GameData(float gravity, float drag, float angularDrag)
    {
      this.gravity = gravity;
      this.drag = drag;
      this.angularDrag = angularDrag;
    }
}
