
using System;

public class SkeletonArcher : MonsterController
{
    private void Awake()
    {
        name = "SkeletonArcher";
    }

    public override void getTurn()
    {
        //행동을 할지에 대한 정보
        float damage = 15;
        BattleManager.Instance.notifyAttackToPlayer(BattleManager.attackType.Pierce,(int)damage);
        //BattleManager에게 턴이 끝났음을 알림
        BattleManager.Instance.notifyTurnEnd();
    }

}