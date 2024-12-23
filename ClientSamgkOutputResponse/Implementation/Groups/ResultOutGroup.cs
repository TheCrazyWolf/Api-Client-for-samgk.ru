using ClientSamgkOutputResponse.Interfaces.Groups;
using ClientSamgkOutputResponse.Interfaces.Identity;

namespace ClientSamgkOutputResponse.Implementation.Groups;

public class ResultOutGroup : IResultOutGroup
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public IResultOutIdentity? Currator { get; set; }
    public int Course => CalculateCourseOfEducation(DateTime.Now);
    int CalculateCourseOfEducation(DateTime dateOfCalculate)
    {
        var parts = Name.Split('-');

        if (parts.Length <= 2 || !int.TryParse(parts[1], out int shortEnrollmentYear))
            return 0;

        int enrollmentYear = 2000 + shortEnrollmentYear;

        return dateOfCalculate.Month >= 9
            ? dateOfCalculate.Year - enrollmentYear + 1
            : dateOfCalculate.Year - enrollmentYear;
    }

}