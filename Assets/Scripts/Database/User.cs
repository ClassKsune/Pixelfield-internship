using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User
{
    /// Save hash auto generated for online save files
    public string hash;

    /// What to save
    public float gravityStrenght;
    public float drag;
    public float angularDrag;

    public User(string hash, float gravityStrenght, float drag, float angularDrag)
    {
      this.hash = hash;
      this.gravityStrenght = gravityStrenght;
      this.drag = drag;
      this.angularDrag = angularDrag;
    }
}
