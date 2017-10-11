
namespace Store.Models
{
    public class OrderModel
    {
        public int Type { get; set; }

        public int Body { get; set; }

        public int Wheels { get; set; }

        public int Engine { get; set; }

        public int Breaks { get; set; }

        public int Suspension { get; set; }

        public int Hydraulics { get; set; }

        public int Cabin { get; set; }

        public bool WheelBalancing { get; set; }

        public bool ChangeSeat { get; set; }
    }
}

/*
     кузова, колес, двигателя, тормозов, ходовой, гидравлики (только для грузовиков),
     салон и поручни (только для автобусов). У каждого перечисленного узла есть текущее
     состояние от 0 до 100 (100 новая, 0 не рабочая). Дополнительные услуги (по желанию
     клиента): легковому автомобилю делают балансировку колес (100грн), автобусу – смену 
     обивки сидений в салоне (300 грн).
*/
