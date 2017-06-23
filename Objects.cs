using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    public abstract class Object
    {
        public float speed;
        public Sprite sprite;
        public Vector2 position;
        public Object(float speed, Sprite sprite, Vector2 position)
        {
            this.speed = speed;
            this.sprite = sprite;
            this.position = position;
        }
    }

    class Enemy : Object
    {
        private int health;
        public Enemy(float speed, Sprite sprite, Vector2 position, int health) : base(speed, sprite, position) {
            this.health = health;
        }
    }

    class Player : Object
    {
        private int health;
        public Player(float speed, Sprite sprite, Vector2 position, int health) : base(speed, sprite, position) {
            this.health = health;
        }
    }

    class Projectile : Object
    {
        public Projectile(float speed, Sprite sprite, Vector2 position) : base(speed, sprite, position) {
        }
    }

    class Pickup : Object
    {
        public Pickup(float speed, Sprite sprite, Vector2 position) : base(speed, sprite, position) {
        }
    }

    public abstract class ObjectCreator
    {
        public abstract Object Instantiate(float speed, Sprite sprite, Vector2 position);
        public abstract Object Instantiate(float speed, Sprite sprite, Vector2 position, int health);
    }

    public class EnemyCreator : ObjectCreator
    {
        public override Object Instantiate(float speed, Sprite sprite, Vector2 position)
        {
            return new Enemy(speed, sprite, position, 3);
        }

        public override Object Instantiate(float speed, Sprite sprite, Vector2 position, int health)
        {
            return new Enemy(speed, sprite, position, health);
        }
    }

    public class PlayerCreator : ObjectCreator
    {
        public override Object Instantiate(float speed, Sprite sprite, Vector2 position)
        {
            return new Player(speed, sprite, position, 3);
        }

        public override Object Instantiate(float speed, Sprite sprite, Vector2 position, int health)
        {
            return new Player(speed, sprite, position, health);
        }
    }

    public class ProjectileCreator : ObjectCreator
    {
        public override Object Instantiate(float speed, Sprite sprite, Vector2 position)
        {
            return new Projectile(speed, sprite, position);
        }

        public override Object Instantiate(float speed, Sprite sprite, Vector2 position, int health)
        {
            return new Projectile(speed, sprite, position);
        }
    }

    public class PickupCreator : ObjectCreator
    {
        public override Object Instantiate(float speed, Sprite sprite, Vector2 position)
        {
            return new Pickup(speed, sprite, position);
        }

        public override Object Instantiate(float speed, Sprite sprite, Vector2 position, int health)
        {
            return new Pickup(speed, sprite, position);
        }
    }
}
