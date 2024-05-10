using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelestialBody : MonoBehaviour
{
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    Vector3 currentVelocity;

    public void Awake() {
        currentVelocity = initialVelocity;
    }

    public void UpdateVelocity(CelestialBody[] bodies, float timeStep) {
        foreach (var otherBody in bodies) {
            if (otherBody != this) {
                float sqrtDistance = (otherBody.transform.position - transform.position).sqrMagnitude;
                Vector3 forceDirection = (otherBody.transform.position = transform.position).normalized;
                Vector3 force = forceDirection * mass * otherBody.mass / sqrtDistance; // Need to add a G constant in Universe Class
                Vector3 acceleration = force / mass;

                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep) {
        transform.position += currentVelocity * timeStep;
    }
}
