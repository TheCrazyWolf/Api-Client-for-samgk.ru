using System.ComponentModel.DataAnnotations;

namespace ClientSamgkOutputResponse.Enums;

public enum ScheduleCallType
{
    [Display(Name = "Обычное")]
    Standart,
    [Display(Name = "Обычное сокращенное")]
    StandartShort,
    [Display(Name = "Обычное супер-сокращенное")]
    StandartSuperShort,
    [Display(Name = "Обычное со сдвигом")]
    StandartWithShift,
    [Display(Name = "Обычное сокращенное со сдвигом")]
    StandartWithShiftShort
}