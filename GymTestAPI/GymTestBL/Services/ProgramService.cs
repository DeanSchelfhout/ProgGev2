using GymTestBL.Interfaces;
using GymTestBL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymTestBL.Services
{
    public class ProgramService
    {
        private IProgramRepository _programRepository;
        public ProgramService(IProgramRepository programRepository)
        {
            this._programRepository = programRepository;
        }
        public bool DeleteProgram(string id)
        {
            try
            {
                _programRepository.DeleteProgram(id);
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
                if (programModel == null) throw new Exception("AddProgram - programModel is null");
                return _programRepository.AddProgram(programModel);
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
                if (programModel == null) throw new Exception("UpdateProgram - programModel is null");
                _programRepository.UpdateProgram(programModel);
                return programModel;
            }
            catch (Exception ex)
            {

                throw new Exception("UpdateProgram", ex);
            }
        }
    }
}
