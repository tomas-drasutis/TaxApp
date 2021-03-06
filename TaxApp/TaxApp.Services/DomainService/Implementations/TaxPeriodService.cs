﻿using System;
using TaxApp.Services.DomainServices;
using TaxApp.Services.Exceptions;

namespace TaxApp.Services.DomainService.Implementations
{
    public class TaxPeriodService : ITaxPeriodService
    {
        public void ValidatePeriod(DateTime startDate, DateTime endDate)
        {
            var periodLength = (endDate - startDate).Days + 1;

            if (periodLength == 1)
                return;

            int daysInWeek = 7;
            int daysInMonth = DateTime.DaysInMonth(startDate.Year, startDate.Month);
            int daysInYear = DateTime.IsLeapYear(startDate.Year) ? 366 : 365;

            if (startDate.DayOfYear == 1 && periodLength == daysInYear)
                return;

            if (startDate.Day == 1 && periodLength == daysInMonth)
                return;

            if (startDate.DayOfWeek == DayOfWeek.Monday && periodLength == daysInWeek)
                return;

            throw new TaxAppValidationException("Invalid period range between start date and end date.");
        }
    }
}
