using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Identity;
using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Utils;

public static class AdditionalLessonsExtensions
{
    public static IList<IResultOutLesson> AddTalkImportantLesson(this IList<IResultOutLesson> lessons)
    {
        var lesson = lessons.First();
        var newLesson = new ResultOutResultOutLesson()
        {
            NumLesson = 0,
            NumPair = 0,
            Durations = [new DurationLessonDetails(new TimeOnly(08, 25), new TimeOnly(09, 10))],
            SubjectDetails = new ResultOutSubject(0, "КЧ.01", "Классный час «Разговоры о важном»"),
            Cabs = lesson.Cabs,
            EducationGroup = lesson.EducationGroup,
        };

        lessons.Add(newLesson);
        return lessons;
    }

    public static IList<IResultOutLesson> AddRussianMyHorizonTalk(this IList<IResultOutLesson> lessons)
    {
        var lesson = lessons.First();
        var newLesson = new ResultOutResultOutLesson()
        {
            NumLesson = 0,
            NumPair = 0,
            Durations = [new DurationLessonDetails(new TimeOnly(08, 25), new TimeOnly(09, 10))],
            SubjectDetails = new ResultOutSubject(0, "КЧ.02", "Классный час «Россия. Мои горизонты»"),
            Cabs = lesson.Cabs,
            EducationGroup = lesson.EducationGroup,
            Identity = [new ResultOutIdentity(1923, "Видинеев Дмитрий Юрьевич")],
        };

        lessons.Add(newLesson);
        return lessons;
    }

    public static IList<IResultOutLesson> SortByLessons(this IList<IResultOutLesson> lesson) =>
        lesson.OrderBy(l => l.NumPair).ThenBy(x => x.NumLesson).ToList();

    public static IList<IResultOutLesson> RemoveDuplicates(this IList<IResultOutLesson> lesson) =>
        lesson.GroupBy(l => new
        {
            l.NumPair,
            l.NumLesson,
            l.EducationGroup?.Id,
            SubjectName = l.SubjectDetails.FullSubjectName
        }).Select(g => g.First()).ToList();
}