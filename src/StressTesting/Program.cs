﻿namespace StressTesting
{
    using System.Diagnostics;
    using HairbrushPlugin.Model;
    using HairbrushPlugin.Wrapper;
    using NickStrupat;

    /// <summary>
    /// Класс для нагрузочного тестирования.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа.
        /// </summary>
        /// <param name="args">Аргументы.</param>
        private static void Main(string[] args)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var parameters = new HairbrushParameters();
            var streamWriter = new StreamWriter("log.txt", true);
            var count = 0;
            while (true)
            {
                const double gigabyteInByte = 0.000000000931322574615478515625;
                var builder = new HairbrushBuilder();
                builder.BuildHairbrush(parameters);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }
        }
    }
}