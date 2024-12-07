using GymTestBL.Interfaces;
using GymTestBL.Models;
using GymTestDL.Mappers;
using GymTestDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestDL.Repositories
{
    public class EquipmentRepositoryEF : IEquipmentRepository
    {
        private GymTestContext _context;
        public EquipmentRepositoryEF(GymTestContext context)
        {
            _context = context;
        }
        private void SaveAndClear()
        {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        public bool DeleteEquipment(int id)
        {
            try
            {
                _context.Equipment.Remove(new EquipmentEF() { EquipmentId = id });
                SaveAndClear();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteEquipment", ex);
            }
        }
        public Equipment AddEquipment(Equipment equipment)
        {
            try
            {
                var equipmentDB = EquipmentMapper.MapToDL(equipment);
                _context.Equipment.Add(equipmentDB);
                _context.SaveChanges();
                return EquipmentMapper.MapToBL(equipmentDB);

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
                var equipmentDB = _context.Equipment.Find(id);

                if (equipmentDB == null) { throw new Exception("ToggleEquipment - Equipment not found"); }

                var equipment = equipmentDB;
                equipment.IsInService = !equipment.IsInService;

                _context.Entry(equipmentDB).CurrentValues.SetValues(equipment);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("ToggleEquipment", ex);
            }
        }
    }
}
