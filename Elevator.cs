using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5B
{
    enum Action
    {
        Up,
        Down,
        Open,
        Closed
    }

    class Elevator
    {
        private int floor;
        private int maxFloor;
        private Action status;

        public Elevator()
        {
            maxFloor = 2;
            status = Action.Closed;
            floor= 1;
        }

        public Elevator(int maxFloor)
        {
            this.maxFloor = maxFloor;
            this.status = Action.Closed;
            this.floor = 1;
        }

        public string Up()
        {
            if (floor== maxFloor) return "Лифт не может поднятся, это максимальный этаж!"; //Лифт не может поднятся это максимальный этаж!
            if (status == Action.Open) return "Лифт не может поднятся, двери открыты!";
            floor++;
            status = Action.Down;
            return $"Лифт едет вверх! Этаж: {floor}!";
        }

        public string Down()
        {
            if (floor== 1) return "Лифт не может опустится, это первый этаж!";
            if (status == Action.Open) return "Лифт не может опустится, двери открыты!";
            status = Action.Down;
            floor--;
            return $"Лифт едет вниз! Этаж: {floor}!";
        }

        public string End()
        {
            status = Action.Closed;
            return $"Лифт приехал! Этаж: {floor}!";
        }

        public string Open()
        {
            if (status == Action.Down || status == Action.Up) return "Лифт не может открыть двери, он в движении!";
            if (status == Action.Open) return "Лифт не может открыть двери! Двери уже открыты!";
            status = Action.Open;
            return $"Двери открыты! Этаж: {floor}!";
        }

        public string Close()
        {
            if (status == Action.Down || status == Action.Up) return "Лифт не может закрыть двери, он в движении!";
            if (status == Action.Closed) return "Лифт не может закрыть двери! Двери уже закрыты!";
            status = Action.Closed;
            return "Двери закрыты!";
        }

        public string GetFloor()
        {
            return $"Текущий этаж: {floor}";
        }

        public string GetMaxFloor()
        {
            return $"Этажи: {maxFloor}";
        }

        public string GetStatus()
        {
            string curStatus = "";
            switch (status)
            {
                case Action.Closed:
                    curStatus = "закрыт";
                    break;
                case Action.Open:
                    curStatus = "открыт";
                    break;
                case Action.Down:
                    curStatus = "едет вниз";
                    break;
                case Action.Up:
                    curStatus = "едет вверх";
                    break;
            }
            return $"Состояние лифта: {curStatus}";
        }

        public int Floor
        {
            get
            {
                return floor;
            }
        }

        public int MaxFloor
        {
            get
            {
                return maxFloor;
            }
        }

        public Action Status
        {
            get
            {
                return status;
            }
        }
    }

}
