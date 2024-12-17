using ClientSamgkOutputResponse.Implementation.Education;
using ClientSamgkOutputResponse.Implementation.Identity;
using ClientSamgkOutputResponse.Implementation.Schedule;
using ClientSamgkOutputResponse.Interfaces.Identity;
using ClientSamgkOutputResponse.Interfaces.Schedule;

namespace ClientSamgk.Utils;

public static class AdditionalLessonsExtensions
{
    public static IList<IResultOutLesson> AddTalkImportantLesson(this IList<IResultOutLesson> lesson)
    {
        var newLesson = new ResultOutResultOutLesson
        {
            NumLesson = 0, NumPair = 0, 
            Durations = new List<DurationLessonDetails>() {new DurationLessonDetails(new TimeOnly(08,25),new TimeOnly(09,10))},
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
    
    public static IList<IResultOutLesson> AddRussianMyHorizonTalk(this IList<IResultOutLesson> lesson)
    {
        var newLesson = new ResultOutResultOutLesson
        {
            NumLesson = 0, NumPair = 0, 
            Durations = new List<DurationLessonDetails>() {new DurationLessonDetails(new TimeOnly(08,25),new TimeOnly(09,10))},
            SubjectDetails = new ResultOutSubject
            {
                Id = 0,
                Index = "КЧ.02",
                SubjectName = "Классный час «Россия. Мои горизонты»"
            },
            Cabs = lesson.First().Cabs, EducationGroup = lesson.First().EducationGroup, 
            Identity = new List<IResultOutIdentity>(){ new ResultOutIdentity() { Id = 1923, Name = "Видинеев Дмитрий Юрьевич"}}
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
                l.EducationGroup?.Id,
                SubjectName = l.SubjectDetails.FullSubjectName })
            .Select(g => g.First())
            .ToList();
    }

}