﻿namespace ExtremeCodeBot.Infrastructure.Settings
{
    public class DbSettings
    {
        public string? Host { get; set; }
        public int Port { get; set; }
        public string DbName { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Schema { get; set; }
        public int MaxPoolSize { get; set; }
    }
}