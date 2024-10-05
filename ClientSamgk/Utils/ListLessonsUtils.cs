using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Utils;

public static class ListLessonsUtils
{
    public static IList<IResultOutLesson> AddTalkImportantLesson(this IList<IResultOutLesson> lesson, DateTime date)
    {
        var newLesson = new ResultOutResultOutLesson
        {
            NumLesson = 0, NumPair = 0, 
            DurationStart = new DateTime(date.Year, date.Month, date.Day, 08,25, 00),
            DurationEnd = new DateTime(date.Year, date.Month, date.Day, 09,10, 00),
            SubjectDetails = new ResultOutSubject
            {
                Id = 0,
                Index = "КЧ.01",
                SubjectName = "Классный час «Разговоры о важном»"
            },
            Cabs = lesson.First().Cabs, EducationGroup = lesson.First().EducationGroup, 
            Identity = lesson.First().Identity
        };
        
        lesson.Add(newLesson);
        return lesson;
    }
    
    public static IList<IResultOutLesson> AddRussianMyHorizonTalk(this IList<IResultOutLesson> lesson, DateTime date)
    {
        var newLesson = new ResultOutResultOutLesson
        {
            NumLesson = 0, NumPair = 0, 
            DurationStart = new DateTime(date.Year, date.Month, date.Day, 08,25, 00),
            DurationEnd = new DateTime(date.Year, date.Month, date.Day, 09,10, 00),
            SubjectDetails = new ResultOutSubject
            {
                Id = 0,
                Index = "КЧ.02",
                SubjectName = "Классный час «Россия. Мои горизонты»"
            },
            Cabs = lesson.First().Cabs, EducationGroup = lesson.First().EducationGroup, 
            Identity = lesson.First().Identity
        };
        
        lesson.Add(newLesson);
        return lesson;
    }
    
    public static IList<IResultOutLesson> SortByLessons(this IList<IResultOutLesson> lesson)
    {
        return lesson.OrderBy(x => x.NumPair).ThenBy(x => x.NumLesson).ToList();
    }
    
    public static IList<IResultOutLesson> RemoveDuplicates(this IList<IResultOutLesson> lesson)
    {
        return lesson.GroupBy(l => new {
                l.NumPair,
                l.NumLesson,
                SubjectName = l.SubjectDetails.FullSubjectName })
            .Select(g => g.First())
            .ToList();
    }

}