namespace YourMoney.Standard.Core.Entities
{
    public interface IBaseEnitity<TKey>
    {
        TKey Id { get; set; }
    }
}