using System.ComponentModel.DataAnnotations;

namespace ClientSamgk.Models.Enums.Schedule;

public enum ScheduleCallType
{
    [Display(Name = "Обычное (до 05.11.25)")]
    Standart,
    [Display(Name = "Обычное сокращенное (до 05.11.25)")]
    StandartShort,
    [Display(Name = "Сокращенное (занятие менее 1ч.)")]
    SuperShort,
    [Display(Name = "Обычное со сдвигом")]
    StandartWithShift,
    [Display(Name = "Сокращенное (занятие менее 1ч.) со сдвигом")]
    SuperShortWithShift,
    [Display(Name = "Сокращенное со сдвигом")]
    ShortWithShift,
    [Display(Name = "ОБЫЧНОЕ_05.11.25")]
    StandartWith05112025,
    [Display(Name = "ОБЫЧНОЕ_СОКР_ЗАН_1ЧАС_БЕЗ_СДВИГА_С_05.11.25")]
    StandartShortWith05112025,
}