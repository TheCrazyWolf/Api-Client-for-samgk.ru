namespace ClientSamgkOutputResponse.Interfaces.Cabs;

public interface IResultOutCab
{
    /// <summary>
    /// Полный адрес кабинета
    /// </summary>
    public string Adress { get; set; }
    
    /// <summary>
    /// № Учебного корпуса
    /// </summary>
    public int Campus { get; set; }

    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string Auditory { get; set; }
}