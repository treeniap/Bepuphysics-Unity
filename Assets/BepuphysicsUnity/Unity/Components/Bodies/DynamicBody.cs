﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BepuPhysicsUnity {
    public class DynamicBody : PhysicBody, IDynamicBody, IBodyUpdate, IPhysicsBody
    {
        private List<BepuPhysicsUnity> PhysicsSpaces;
        private DetectionBehaviour Detection;
        [SerializeField]
        private float Mass = 1;
        private int ID = -1;
        private BepuPhysicsUnity physicSpace;

        public void OnBodyUpdated(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        void OnEnable()
        {
            PhysicsSpaces = new List<BepuPhysicsUnity>(FindObjectsOfType<BepuPhysicsUnity>());
            Detection = GetComponent<DetectionBehaviour>();
            if (PhysicsSpaces.Count > 0)
            {
                PhysicsSpaces[0].AddShape(transform.position, transform.rotation, this, Detection, Mass, OnShapeAdded);
                physicSpace = PhysicsSpaces[0];
            }
        }

        void OnDisable()
        {
            if(ID != -1)
                physicSpace.RemoveDynamicBody(ID);
        }

        public float GetMass()
        {
            return Mass;
        }

        public void SetMass(float mass)
        {
            mass = Mass;
        }

        public void AddForce(Vector3 vector3)
        {

        }

        public void AddTorque(Vector3 vector3)
        {

        }

        public void SetPosition(Vector3 position)
        {

        }

        public void SetRotation(Quaternion rotation)
        {

        }

        private void OnShapeAdded(int id)
        {
            ID = id;
            physicSpace.SubscribePhysicsUpdate(this, id);
        }

        public Vector3 GetVelocity()
        {
            throw new System.NotImplementedException();
        }

        public Vector3 GetAngularVelocity()
        {
            throw new System.NotImplementedException();
        }
    }
}
