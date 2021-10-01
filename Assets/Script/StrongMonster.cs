namespace Script
{
    public class StrongMonster : LivingEntity
    {
        protected override void Animation()
        {
            // 걷는 모션
            _skeletonAnimation.AnimationName = "Walk";
        }
        
        protected override void DamageControl()
        {
            Damage = 5;
        }
        
        protected override void WalkSpeedControl()
        {
            moveSpeed = 10;
        }
    }
}
