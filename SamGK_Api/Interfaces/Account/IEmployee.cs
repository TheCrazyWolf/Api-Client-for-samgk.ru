namespace SamGK_Api.Interfaces.Account;

public interface IEmployee
{
    /// <summary>
    /// ID сотрудника
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Фамилия Имя Отчество сотрудника
    /// </summary>
    public string Name { get; set; }
    
    /* Особое мнение TheCrazyWolf
     *
     * Можно столкнутся с двойными пробелами
     * Особенно после отчества
     */
}