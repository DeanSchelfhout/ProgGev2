using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Interfaces
{
    public interface IEquipmentRepository
    {
        bool DeleteEquipment(int Id);
        Equipment AddEquipment(Equipment equipment);
        bool ToggleInService(int Id);
    }
}
