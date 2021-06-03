using System;
using System.Collections.Generic;

namespace SIGO.Infrastructure.CrossCutting
{
    public class AppConfiguration
    {
        public static IDictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();

        public static string ConnectionString { get; set; }

        public static RabbitMqConfiguration RabbitMqConfiguration { get; set; }

        public static T GetSettingsValue<T>(string name)
        {
            T newValue = default;
            try
            {
                Settings.TryGetValue(name, out var value);

                newValue = (T)Convert.ChangeType(value, typeof(T));
            }
            catch (Exception) { }

            return newValue;
        }

        public static string GetSettingsValue(string name)
        {
            Settings.TryGetValue(name, out var value);

            return value;
        }
    }

    public class RabbitMqConfiguration
    {
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VirtualHost { get; set; }
        public int Port { get; set; }
    }
}
