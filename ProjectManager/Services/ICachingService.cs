﻿namespace ProjectManager.Services
{
    public interface ICachingService
    {
        bool IsExpired { get; }

        void ResetCache();

        object GetCacheValue(string className, string methodName);

        void AddCacheValue(string className, string methodName, object value);
    }
}
