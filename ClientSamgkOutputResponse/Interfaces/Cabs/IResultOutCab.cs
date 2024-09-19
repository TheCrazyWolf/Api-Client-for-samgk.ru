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
    public int Campus { get;}

    /// <summary>
    /// Номер кабинета
    /// </summary>
    public string Auditory { get;}
}