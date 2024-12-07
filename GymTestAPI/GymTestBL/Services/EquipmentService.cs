using GymTestBL.Interfaces;
using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Services
{
    public class EquipmentService
    {
        private IEquipmentRepository _equipmentRepository;
        public EquipmentService(IEquipmentRepository equipmentRepository)
        {
            this._equipmentRepository = equipmentRepository;
        }
        public bool DeleteEquipment(int id)
        {
            try
            {
                _equipmentRepository.DeleteEquipment(id);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteEquipment",ex);
            }
        }
        public Equipment AddEquipment(Equipment equipment)
        {
            try
            {
                if (equipment == null) throw new Exception("AddEquipment - equipment is null");
                return _equipmentRepository.AddEquipment(equipment);
            }
            catch (Exception ex)
            {

                throw new Exception("AddEquipment", ex);
            }
        }
        public bool ToggleInService(int id)
        {
            try
            {
                _equipmentRepository.ToggleInService(id);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("ToggleInService", ex);
            }
        }
    }
}
