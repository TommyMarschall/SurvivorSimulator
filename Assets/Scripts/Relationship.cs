using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship
{
    public Contestant otherContestant;
    public float relationshipValue = 0f;

    public Relationship(Contestant otherContestant)
    {
        this.otherContestant = otherContestant;
    }
    public void ChangeRelationship(float relationshipValue)
    {
        this.relationshipValue += relationshipValue;
    }
  
}
