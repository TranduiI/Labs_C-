using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba13_B
{
    class TrolleyBus
    {
        static private readonly DateTime startWorkingTime;

        private readonly int trNum;
        public int TrNum
        {
            get { return trNum; }
        }
        public static int Count { get; set; }

        static TrolleyBus()
        {
            startWorkingTime = DateTime.Now;
        }
        public TrolleyBus()
        {

        }
        private TrolleyBus(int trNum)
        {
            this.trNum = trNum;
        }
        public bool HasLeft { get; private set; }
        

        public string Drive()
        {
            HasLeft = true;
            return $"\nТроллейбус №{trNum} выехал в {DateTime.Now.ToLongTimeString()} (через {Math.Round(DateTime.Now.Subtract(startWorkingTime).TotalSeconds, 0)} сек) после начала работы парка в {startWorkingTime.ToLongTimeString()}";
        }
        public static ObservableCollection<TrolleyBus> GetTrolleyBuses()
        {
            ObservableCollection<TrolleyBus> result = new ObservableCollection<TrolleyBus>();
            for (int i = 0; i < Count; i++)
            {
                result.Add(new TrolleyBus(i + 1));
            }
            return result;
        }

    }
}
