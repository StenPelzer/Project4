using UnityEngine;
using UnityEditor;
using System;

public class Utils : ScriptableObject
{
    [MenuItem("Tools/MyTool/Do It in C#")]
    static void DoIt()
    {
        EditorUtility.DisplayDialog("MyTool", "Do It in C# !", "OK", "");
    }


    public interface Option<T>
    {
        U Visit<U>(Func<U> onNone, Func<T, U> onSome);
        void Visit(Action onNone, Action<T> onSome);
    }
    public class None<T> : Option<T>
    {
        public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
        {
            return onNone();
        }
        public void Visit(Action onNone, Action<T> onSome)
        {
            onNone();
        }
    }
    public class Some<T> : Option<T>
    {
        T value;
        public Some(T value)
        {
            this.value = value;
        }
        public U Visit<U>(Func<U> onNone, Func<T, U> onSome)
        {
            return onSome(value);
        }
        public void Visit(Action onNone, Action<T> onSome)
        {
            onSome(value);
        }
    }
    public interface Iterator<T>
    {
        Option<T> GetNext();
        Option<T> GetCurrent();
        void Reset();
    }
    public interface DrawVisitor
    {
        void DrawPlayer(Player player);
        void DrawEnemy(Enemy enemy);
        void DrawPickup(Pickup pickup);
        void DrawProjectile(Projectile projectile);
    }
    public interface UpdateVisitor
    {
        void UpdatePlayer(Player player, float dt);
        void UpdateEnemy(Enemy enemy, float dt);
        void UpdatePickup(Pickup pickup, float dt);
        void UpdateProjectile(Projectile projectile, float dt);
    }

    public interface Updateable { void Update(UpdateVisitor visitor, float dt); }
    public interface Drawable { void Draw(DrawVisitor visitor); }

    public class DefaultUpdateVisitor : UpdateVisitor
    {
        public void UpdateEnemy(Enemy enemy, float dt)
        {
            throw new NotImplementedException();
        }

        public void UpdatePickup(Pickup pickup, float dt)
        {
            throw new NotImplementedException();
        }

        public void UpdatePlayer(Player player, float dt)
        {
            throw new NotImplementedException();
        }

        public void UpdateProjectile(Projectile projectile, float dt)
        {
            throw new NotImplementedException();
        }
    }
    public class DefaultDrawVisitor : DrawVisitor
    {
        public void DrawEnemy(Enemy enemy)
        {
            throw new NotImplementedException();
        }

        public void DrawPickup(Pickup pickup)
        {
            throw new NotImplementedException();
        }

        public void DrawPlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public void DrawProjectile(Projectile projectile)
        {
            throw new NotImplementedException();
        }
    }
}