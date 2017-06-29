using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisitor  {
    void Visit<U>(Func<U> onEnemy, Func<U> onPlayer, Func<U> onProjectile, Func<U> onPowerup);
}
