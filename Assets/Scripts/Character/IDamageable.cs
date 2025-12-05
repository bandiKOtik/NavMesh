public interface IDamageable
{
    public float Health { get; protected set; }
    public void Heal(float amout);
    public void DealDamage(float amount);
}
