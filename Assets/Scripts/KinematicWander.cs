using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicWander : MonoBehaviour
{
    float maxSpeed = 5f; //speed of enemy
    float maxRotation = 1f;
    public Transform enemy; //seeker

    //class to hold velocity and orientation
    class KinematicSteeringOutput
    {
        public Vector3 velocityTrans;
        public Vector3 velocityAng;
    }

    //update loop to update position and orientation from other functions
    void FixedUpdate()
    {
        KinematicSteeringOutput blackMagic = getSteering();
        enemy.transform.position += blackMagic.velocityTrans * Time.deltaTime; //updates translational pos
        enemy.transform.eulerAngles = blackMagic.velocityAng; //updates rotational pos
    }

    //creates object with velocity and orientation, then canlculates and returns new orientation and velocity
    KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocityTrans = maxSpeed * enemy.eulerAngles;
        Debug.Log(result.velocityTrans);
        //float angleDeg = randomBinomial() * maxRotation;
        //Debug.Log(randomBinomial());
        //angleDeg *= Mathf.Rad2Deg; //turn rad to deg
        result.velocityAng = new Vector3(0, randomBinomial() * maxRotation, 0);
        //Debug.Log(result.velocityAng);
        //Debug.Log(result.velocityAng);

        return result;
    }
    
    float randomBinomial()
    {
        return ((float)Random.Range(0, 100) / 100);// - ((float)Random.Range(0, 100) / 100);
    }

}
