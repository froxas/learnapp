namespace learnapp.Model
{
    public interface IJoinEntity<TEntity>
    {
        TEntity Navigation { get; set; }
    }
}