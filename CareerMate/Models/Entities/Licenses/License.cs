using FileSource.Abstractions.Enums;
using FileSource.Models.Entities.Customers;
using System;

namespace FileSource.Models.Entities.Licenses
{
    public class License : Entity
    {
        public License(
            LicenseTypes type,
            int dailyLimit,
            int validDays,
            DateOnly validTill,
            int todayLimit)
        {
            Type = type;
            DailyLimit = dailyLimit;
            ValidDays = validDays;
            ValidTill = validTill;
            TodayLimit = todayLimit;
        }

        public LicenseTypes Type { get; private set; }

        public int DailyLimit { get; private set; }

        public int TodayLimit { get; private set; }

        public int ValidDays { get; private set; }

        public DateOnly ValidTill { get; private set; }

        public bool IsAlreadyUsed { get; private set; }

        public Customer Customer { get; private set; }

        public DateTime? DeletedAt { get; private set; }

        public void SetTodayLimit(int todayLimit)
        {
            TodayLimit = todayLimit;
        }

        public void Delete()
        {
            DeletedAt = DateTime.UtcNow;
        }
    }
}
