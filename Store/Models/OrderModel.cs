using System.ComponentModel;

namespace Store.Models
{
    public class OrderModel
    {
        [DisplayName("Кузов")]
        public int Body { get; set; }

        [DisplayName("Колеса")]
        public int Wheels { get; set; }

        [DisplayName("Двигатель")]
        public int Engine { get; set; }

        [DisplayName("Тормоза")]
        public int Breaks { get; set; }

        [DisplayName("Ходовая")]
        public int Suspension { get; set; }

        [DisplayName("Гидравлика")]
        public int? Hydraulics { get; set; }

        [DisplayName("Салон и поручни")]
        public int? Cabin { get; set; }

        [DisplayName("Балансировка колес")]
        public bool WheelBalancing { get; set; }

        [DisplayName("Смена обивки сидений")]
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
