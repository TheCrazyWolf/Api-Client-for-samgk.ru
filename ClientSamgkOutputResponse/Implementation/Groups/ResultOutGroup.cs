using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Implementation.Groups;

public class ResultOutGroup : IResultOutGroup
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IResultOutIdentity? Currator { get; set; }
    public int Course => CalculateCourseOfEducation(DateTime.Now);

    private int CalculateCourseOfEducation(DateTime dateOfCalculate)
    {
        var arrays = Name.Split('-');
        if (arrays.Length <= 2) return 0;
        if (!int.TryParse(arrays[1], out int shortEnrollmentYear)) return 0;
        // переписать это говно
        int enrollmentYear = 2000 + shortEnrollmentYear;
        var currentDate = dateOfCalculate;
        if (currentDate.Month >= 9)
            return (currentDate.Year - enrollmentYear + 1); 
        return (currentDate.Year - enrollmentYear);
    }
}