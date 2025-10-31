using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repos
{
    public class EFTraineeRepository : ITraineeRepository
    {
        ZelisTrainingEFDBContext ctx;
        public EFTraineeRepository()
        {
            ctx = new ZelisTrainingEFDBContext();
        }
        public async Task AddTraineeAsync(Trainee trainee)
        {
            try
            {
                ctx.Trainees.AddAsync(trainee);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task DeleteTraineeAsync(string trainingId, string empId)
        {
            Trainee trainee = await GetTraineeAsync(trainingId, empId);
            try
            {
                ctx.Trainees.Remove(trainee);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task<List<Trainee>> GetAllTraineesAsync()
        {
            List<Trainee> trainees = await (from t in ctx.Trainees select t).ToListAsync();
            return trainees;
        }

        public async Task<Trainee> GetTraineeAsync(string trainingId, string empId)
        {
            try
            {
                Trainee trainee = await (from t in ctx.Trainees where t.TrainingId == trainingId && t.EmpId == empId select t).FirstAsync();
                return trainee;
            }
            catch (Exception ex)
            {
                throw new TrainingException("No such Trainee with the employee id and training id");
            }
        }

        public async Task<List<Trainee>> GetTraineesByEmpIdAsync(string empId)
        {
            List<Trainee> trainees = await (from t in ctx.Trainees where t.EmpId == empId select t).ToListAsync();
            if (trainees.Count == 0)
                throw new TrainingException("No Trainees with the employee id");
            else
                return trainees;
        }

        public async Task<List<Trainee>> GetTraineesByStatusAsync(string status)
        {
            List<Trainee> trainees = await (from t in ctx.Trainees where t.Status == status select t).ToListAsync();
            if (trainees.Count == 0)
                throw new TrainingException("No Trainees with the given status");
            else
                return trainees;
        }

        public async Task<List<Trainee>> GetTraineesByTrainingIdAsync(string trainingId)
        {
            List<Trainee> trainees = await (from t in ctx.Trainees where t.TrainingId == trainingId select t).ToListAsync();
            if (trainees.Count == 0)
                throw new TrainingException("No Trainees with the given status");
            else
                return trainees;
        }

        public async Task InsertEmployee(Employee employee)
        {
            try
            {
                await ctx.Employees.AddAsync(employee);
                await ctx.SaveChangesAsync();
            }
            catch (TrainingException ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task UpdateTraineeAsync(string trainingid, string empid, string status)
        {
            try
            {
                Trainee trainee = await GetTraineeAsync(trainingid, empid);
                trainee.Status = status;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException("No such trainee!!");
            }
        }

    }
}
