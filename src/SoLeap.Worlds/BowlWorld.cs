﻿using BulletSharp;

namespace SoLeap.Worlds
{
    public class BowlWorld : AbstractPhysicsWorld
    {
        private const float bowlDiameter = 150f;
        private const float bowlHeight = 40f;
        private const float bowlThickness = 7f;

        private const float ballRadius = 25f;

        private const float sceneHeight = 100f;

        private const float gravity = 500f;

        public BowlWorld()
            : base(new Vector3(0f, -gravity, 0f)) { }

        protected override void SetupScene()
        {
            // create static ground
            BoxShape groundShape = new BoxShape(1000f, 10f, 1000f);
            Add(groundShape);

            CreateAndAddRigidBody(0f, Matrix.Translation(0, sceneHeight, 0), groundShape, "Ground");

            // create two bowls
            float innerDiameter2 = (bowlDiameter - bowlThickness) / 2.0f;
            float diameter2 = bowlDiameter / 2.0f;
            float thickness2 = bowlThickness / 2.0f;
            float height2 = bowlHeight / 2.0f;

            CompoundShape bowlShape = new CompoundShape();
            bowlShape.AddChildShape(Matrix.Translation(-innerDiameter2, 0, 0), new BoxShape(thickness2, height2, diameter2));
            bowlShape.AddChildShape(Matrix.Translation(+innerDiameter2, 0, 0), new BoxShape(thickness2, height2, diameter2));
            bowlShape.AddChildShape(Matrix.Translation(0, 0, -innerDiameter2), new BoxShape(diameter2 - 2 * thickness2, height2, thickness2));
            bowlShape.AddChildShape(Matrix.Translation(0, 0, +innerDiameter2), new BoxShape(diameter2 - 2 * thickness2, height2, thickness2));
            bowlShape.AddChildShape(Matrix.Translation(0, -(bowlHeight + bowlThickness) / 2.0f, 0), new BoxShape(diameter2, thickness2, diameter2));
            Add(bowlShape);

            CreateAndAddRigidBody(30.0f, Matrix.Translation(-bowlDiameter, bowlHeight + bowlThickness + sceneHeight, 0), bowlShape, "Left bowl");
            CreateAndAddRigidBody(30.0f, Matrix.Translation(+bowlDiameter, bowlHeight + bowlThickness + sceneHeight, 0), bowlShape, "Right bowl");

            // create the ball
            SphereShape ballShape = new SphereShape(ballRadius);
            Add(ballShape);

            CreateAndAddRigidBody(10.0f, Matrix.Translation(-bowlDiameter, bowlHeight * 2.0f + sceneHeight, 0), ballShape, "Ball");
        }
    }
}