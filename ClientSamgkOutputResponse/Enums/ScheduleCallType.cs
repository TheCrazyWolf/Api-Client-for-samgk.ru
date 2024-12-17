using System.ComponentModel.DataAnnotations;

namespace ClientSamgkOutputResponse.Enums;

public enum ScheduleCallType
{
    [Display(Name = "Обычное")]
    Standart,
    [Display(Name = "Обычное сокращенное")]
    StandartShort,
    [Display(Name = "Сокращенное (занятие менее 1ч.)")]
    SuperShort,
    [Display(Name = "Обычное со сдвигом")]
    StandartWithShift,
    [Display(Name = "Сокращенное (занятие менее 1ч.) со сдвигом")]
    SuperShortWithShift
}