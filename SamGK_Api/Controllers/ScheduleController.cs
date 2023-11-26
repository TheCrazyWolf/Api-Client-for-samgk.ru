using Newtonsoft.Json;
using RestSharp;
using SamGK_Api.Interfaces.Account;
using SamGK_Api.Interfaces.Cabs;
using SamGK_Api.Interfaces.Client;
using SamGK_Api.Interfaces.Groups;
using SamGK_Api.Interfaces.Schedule;
using SamGK_Api.Models.Schedule;

namespace SamGK_Api.Controllers;

public class ScheduleController : _BaseController, ISсheduleController
{
    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IEmployee entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/teacher/{date.ToString("yyyy-MM-dd")}/{entity.Id}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, IEmployee entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/teacher/{date.ToString("yyyy-MM-dd")}/{entity.Id}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, IEmployee entity,
        int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var options =
                new RestRequest(
                    $"https://asu.samgk.ru/api/schedule/teacher/{startDate.ToString("yyyy-MM-dd")}/{entity.Id}",
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = _client.Execute(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            Task.Delay(delay);
        }

        return sсheduleList;
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        IEmployee entity, int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var options =
                new RestRequest(
                    $"https://asu.samgk.ru/api/schedule/teacher/{startDate.ToString("yyyy-MM-dd")}/{entity.Id}",
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = await _client.ExecuteAsync(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            await Task.Delay(delay);
        }

        return sсheduleList;
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, IGroup entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/{entity.Id}/{date.ToString("yyyy-MM-dd")}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, IGroup entity)
    {
        var options =
            new RestRequest($"https://asu.samgk.ru/api/schedule/{entity.Id}/{date.ToString("yyyy-MM-dd")}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, IGroup entity, int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var options =
                new RestRequest($"https://asu.samgk.ru/api/schedule/{entity.Id}/{startDate.ToString("yyyy-MM-dd")}",
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = _client.Execute(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            Task.Delay(delay);
        }

        return sсheduleList;
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate, IGroup entity,
        int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var options =
                new RestRequest($"https://asu.samgk.ru/api/schedule/{entity.Id}/{startDate.ToString("yyyy-MM-dd")}",
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = await _client.ExecuteAsync(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            await Task.Delay(delay);
        }

        return sсheduleList;
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, ICab entity)
    {
        var options =
            new RestRequest(
                $"https://asu.samgk.ru/api/schedule/cabs/{date.ToString("yyyy-MM-dd")}/cabNum/{entity.Name.Replace(@"/", "_")}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, ICab entity)
    {
        var options =
            new RestRequest(
                $"https://asu.samgk.ru/api/schedule/cabs/{date.ToString("yyyy-MM-dd")}/cabNum/{entity.Name.Replace(@"/", "_")}",
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, ICab entity, int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var options =
                new RestRequest(
                    $"https://asu.samgk.ru/api/schedule/cabs/{startDate.ToString("yyyy-MM-dd")}/cabNum/{entity.Name.Replace(@"/", "_")}",
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = _client.Execute(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            Task.Delay(delay);
        }

        return sсheduleList;
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate, ICab entity,
        int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var options =
                new RestRequest(
                    $"https://asu.samgk.ru/api/schedule/cabs/{startDate.ToString("yyyy-MM-dd")}/cabNum/{entity.Name.Replace(@"/", "_")}",
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = await _client.ExecuteAsync(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            await Task.Delay(delay);
        }

        return sсheduleList;
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly date, SheduleSearchType type, string id)
    {
        var url = type switch
        {
            SheduleSearchType.Employee =>
                $"https://asu.samgk.ru/api/schedule/teacher/{date.ToString("yyyy-MM-dd")}/{id}",
            SheduleSearchType.Group => $"https://asu.samgk.ru/api/schedule/{id}/{date.ToString("yyyy-MM-dd")}",
            SheduleSearchType.Cab =>
                $"https://asu.samgk.ru/api/schedule/cabs/{date.ToString("yyyy-MM-dd")}/cabNum/{id}",
            _ => ""
        };

        var options =
            new RestRequest(url,
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = _client.Execute(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly date, SheduleSearchType type, string id)
    {
        var url = type switch
        {
            SheduleSearchType.Employee =>
                $"https://asu.samgk.ru/api/schedule/teacher/{date.ToString("yyyy-MM-dd")}/{id}",
            SheduleSearchType.Group => $"https://asu.samgk.ru/api/schedule/{id}/{date.ToString("yyyy-MM-dd")}",
            SheduleSearchType.Cab =>
                $"https://asu.samgk.ru/api/schedule/cabs/{date.ToString("yyyy-MM-dd")}/cabNum/{id}",
            _ => ""
        };

        var options =
            new RestRequest(url,
                Method.Get);
        options.AddHeaders(GetHeaders());

        var result = await _client.ExecuteAsync(options);

        if (!result.IsSuccessStatusCode || result.Content is null)
            return null;

        var obj = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

        return obj is null ? null : new List<IScheduleDate> { obj };
    }

    public IEnumerable<IScheduleDate>? GetSchedule(DateOnly startDate, DateOnly endDate, SheduleSearchType type,
        string id, int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var url = type switch
            {
                SheduleSearchType.Employee =>
                    $"https://asu.samgk.ru/api/schedule/teacher/{startDate.ToString("yyyy-MM-dd")}/{id}",
                SheduleSearchType.Group => $"https://asu.samgk.ru/api/schedule/{id}/{startDate.ToString("yyyy-MM-dd")}",
                SheduleSearchType.Cab =>
                    $"https://asu.samgk.ru/api/schedule/cabs/{startDate.ToString("yyyy-MM-dd")}/cabNum/{id}",
                _ => ""
            };

            var options =
                new RestRequest(
                    url,
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = _client.Execute(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            Task.Delay(delay);
        }

        return sсheduleList;
    }

    public async Task<IEnumerable<IScheduleDate>?> GetScheduleAsync(DateOnly startDate, DateOnly endDate,
        SheduleSearchType type, string id, int delay = 700)
    {
        var sсheduleList = new List<IScheduleDate>();
        endDate = endDate.AddDays(1);
        while (startDate != endDate)
        {
            var url = type switch
            {
                SheduleSearchType.Employee =>
                    $"https://asu.samgk.ru/api/schedule/teacher/{startDate.ToString("yyyy-MM-dd")}/{id}",
                SheduleSearchType.Group => $"https://asu.samgk.ru/api/schedule/{id}/{startDate.ToString("yyyy-MM-dd")}",
                SheduleSearchType.Cab =>
                    $"https://asu.samgk.ru/api/schedule/cabs/{startDate.ToString("yyyy-MM-dd")}/cabNum/{id}",
                _ => ""
            };

            var options =
                new RestRequest(
                    url,
                    Method.Get);
            options.AddHeaders(GetHeaders());

            var result = await _client.ExecuteAsync(options);

            if (!result.IsSuccessStatusCode || result.Content is null)
                return null;

            var currentScheduleDate = JsonConvert.DeserializeObject<ScheduleDate>(result.Content);

            if (currentScheduleDate?.Lessons.Count() != 0 && currentScheduleDate != null)
                sсheduleList.Add(currentScheduleDate);

            startDate = startDate.AddDays(1);

            await Task.Delay(delay);
        }

        return sсheduleList;
    }
}