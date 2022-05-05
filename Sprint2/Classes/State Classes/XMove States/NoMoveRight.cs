﻿using Microsoft.Xna.Framework;

namespace Sprint5
{
    class PlayerNoMoveRight : PlayerMoveX
    {

        public PlayerNoMoveRight(IGameObject targetObj, bool moving, bool faceRight, bool crouching, IPhysicsX? physicsX = null)
        {
            gameObject = targetObj;
            this.moving = moving;
            this.faceRight = true;
            this.crouching = crouching;
            if (physicsX == null)
            {
                this.physicsX = new PlayerPhysicsX();
            }
            else
            {
                this.physicsX = physicsX;
            }
        }

        public override void Update(GameTime gameTime)
        {
            gameObject.Location = Vector2.Add(gameObject.Location, new Vector2(physicsX.MovementAdjustmentX(gameTime, moving, faceRight), Y_CHANGE));
            if (this.faceRight && this.moving && !this.crouching)
            {
                ((Mario)gameObject).XMoveState = new PlayerMoveRight(gameObject, true, true, crouching, physicsX);
            }
            else if (!this.faceRight && this.moving && !this.crouching)
            {
                ((Mario)gameObject).XMoveState = new PlayerMoveLeft(gameObject, true, false, crouching, physicsX);
            }
            else if (!this.faceRight && !this.moving)
            {
                ((Mario)gameObject).XMoveState = new PlayerNoMoveLeft(gameObject, false, true, crouching, physicsX);
            }
            crouching = false;
        }
    }

    class EnemyNoMoveRight : ItemEnemyMoveX
    {

        public EnemyNoMoveRight(IGameObject targetObj, bool moving, bool faceRight, IPhysicsX? physicsX = null, double maxVelocity = 1.0)
        {
            gameObject = targetObj;
            this.moving = moving;
            this.faceRight = faceRight;
            if (physicsX == null)
            {
                this.physicsX = new EnemyPhysicsX(maxVelocity);
            }
            else
            {
                this.physicsX = physicsX;
            }
        }

        public override void Update(GameTime gameTime)
        {
            gameObject.Location = Vector2.Add(gameObject.Location, new Vector2(physicsX.MovementAdjustmentX(gameTime, moving, faceRight), Y_CHANGE));
            if (this.faceRight && this.moving)
            {
                ((IEnemy)gameObject).XMoveState = new EnemyMoveRight(gameObject, false, true, physicsX);
            }
            else if (!this.faceRight && this.moving)
            {
                ((IEnemy)gameObject).XMoveState = new EnemyMoveLeft(gameObject, false, false, physicsX);
            }
            else if (this.faceRight && !this.moving)
            {
                ((IEnemy)gameObject).XMoveState = new EnemyNoMoveLeft(gameObject, false, true, physicsX);
            }
        }
    }

    class ItemNoMoveRight : ItemEnemyMoveX
    {

        public ItemNoMoveRight(IGameObject targetObj, bool moving, bool faceRight, IPhysicsX? physicsX = null)
        {
            gameObject = targetObj;
            this.moving = moving;
            this.faceRight = faceRight;
            if (physicsX == null)
            {
                this.physicsX = new ItemPhysicsX();
            }
            else
            {
                this.physicsX = physicsX;
            }
        }

        public override void Update(GameTime gameTime)
        {
            gameObject.Location = Vector2.Add(gameObject.Location, new Vector2(physicsX.MovementAdjustmentX(gameTime, moving, faceRight), Y_CHANGE));
            if (this.faceRight && this.moving)
            {
                ((Item)gameObject).XMoveState = new ItemMoveRight(gameObject, false, faceRight, physicsX);
            }
            else if (!this.faceRight && this.moving)
            {
                ((Item)gameObject).XMoveState = new ItemMoveLeft(gameObject, false, faceRight, physicsX);
            }
            else if (this.faceRight && !this.moving)
            {
                ((Item)gameObject).XMoveState = new ItemNoMoveLeft(gameObject, false, true, physicsX);
            }
        }
    }
}