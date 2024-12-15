using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Interfaces
{
    public interface IReservationRepository
    {
        public Reservation Update(Reservation reservation);
        public Reservation Add(Reservation reservation);
        public bool Delete(int id);
    }
}
