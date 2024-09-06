using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    public class Hotel
    {
        private int _capacidadeMaxima;
        private List<Reserva> _reservas = new List<Reserva>();

        public Hotel(int capacidadeMaxima)
        {
            _capacidadeMaxima = capacidadeMaxima;
        }

        public void CriarReserva(DateTime dataCheckIn, DateTime dataCheckOut, int quartos)
        {
            //Validações de entrada
            if (dataCheckIn >= dataCheckOut)
            {
                throw new ArgumentException("Data de checkIn deve ser anterior a data de checkout");
            }
            if (quartos > _capacidadeMaxima)
            {
                throw new InvalidOperationException("Número de quartos excede a capaciade máxima");
            }

            //Criar uma nova reserva e adicionar á lista
            var reserva = new Reserva(dataCheckIn, dataCheckOut, quartos);
            _reservas.Add(reserva);
        }
        public void CancelarReserva(DateTime checkIn, DateTime checkOut)
        {
            _reservas.RemoveAll(r => r.DataCheckIn == checkIn &&
            r.DataCheckOut == checkOut);
        }
        public List<Reserva> ObterReservas()
        {
            return _reservas;
        }
        public decimal CalcularValorTotalReserva(DateTime checkIn, DateTime checkOut, int quartos, decimal precoPorQuarto)
        {
            int noites = (checkOut - checkIn).Days;
            return noites * quartos * precoPorQuarto;
        }
    }
}