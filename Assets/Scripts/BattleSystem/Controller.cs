using System;

namespace DefaultNamespace
{
    public interface Controller
    {

        public abstract bool getTick();
        public abstract void getTurn();
        public abstract void getDamage(BattleManager.attackType type, float damage);
        public abstract void die();
    }
}