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
    public class ProgramRepositoryEF : IProgramRepository
    {
        private GymTestContext _context;
        public ProgramRepositoryEF(GymTestContext context)
        {
            _context = context;
        }
        private void SaveAndClear()
        {
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }
        public bool DeleteProgram(int id)
        {
            try
            {
                _context.ProgramModels.Remove(new ProgramModelEF() { ProgramCode = id });
                SaveAndClear();
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception("DeleteProgram", ex);
            }
        }
        public ProgramModel AddProgram(ProgramModel programModel)
        {
            try
            {
                var programDB = ProgramMapper.MapToDL(programModel);
                _context.ProgramModels.Add(programDB);
                _context.SaveChanges();
                return ProgramMapper.MapToBL(programDB);

            }
            catch (Exception ex)
            {
                throw new Exception("AddProgram", ex);
            }
        }
        public ProgramModel UpdateProgram(ProgramModel programModel)
        {
            try
            {
                var programDB = _context.ProgramModels.Find(programModel.ProgramCode);

                if (programDB == null) { throw new Exception("UpdateProgram - programModel not found"); }

                _context.Entry(programDB).CurrentValues.SetValues(ProgramMapper.MapToDL(programModel));
                _context.SaveChanges();
                return ProgramMapper.MapToBL(programDB);
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateProgram", ex);
            }
        }
    }
}
