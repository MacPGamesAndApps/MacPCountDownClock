using System;
using System.Collections.Generic;
using MacPCountDownClock.Models;
using Microsoft.Maui;

namespace MacPCountDownClock.Helpers
{
    internal static class IOUtils
    {
        private static string _countDownDateTimeStoragePath = FileSystem.Current.AppDataDirectory + "\\CountDownDateTimeStorage.txt";

        internal static void SaveCountDownData(CountDownData countDownData)
        {
            using(StreamWriter streamWriter = new StreamWriter(_countDownDateTimeStoragePath, false))
            {
                streamWriter.WriteLine(countDownData.CounterFor);
                streamWriter.WriteLine(countDownData.CountDownDateTime);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        internal static CountDownData GetCountDownData()
        {
            CountDownData countDownData = new CountDownData ();
            DateTime countDownDateTime = DateTime.Now;
            try
            {
                using (StreamReader streamReader = new StreamReader(_countDownDateTimeStoragePath))
                {
                    countDownData.CounterFor = streamReader.ReadLine();
                    DateTime.TryParse(streamReader.ReadLine(), out countDownDateTime);
                    countDownData.CountDownDateTime = countDownDateTime;
                    streamReader.Close();
                }
            }
            catch (Exception ex)
            {
                countDownData.CounterFor = "Countdown not yet configured";
                countDownData.CountDownDateTime = countDownDateTime;
            }
            return countDownData;
        }
    }
}
