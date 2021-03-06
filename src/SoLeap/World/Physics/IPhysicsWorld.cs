﻿using BulletSharp;
using System.Windows.Media;

namespace SoLeap.World
{
    public interface IPhysicsWorld
        : System.IDisposable
    {
        IDebugDraw DebugDrawer { get; set; }

        void Add(CollisionShape shape);

        void Add(TypedConstraint constraint);

        RigidBody CreateAndAddRigidBody(float mass, Matrix startTransform, CollisionShape shape, object userObject = null, float friction = 1.0f, bool isKinematic = false);

        RigidBody CreateAndAddRigidBodyAndRenderable(float mass, Matrix startTransform, CollisionShape shape, Color color = default(Color), object userObject = null, float friction = 1.0f, bool isKinematic = false);

        void Update();

        void DebugDraw();
    }
}