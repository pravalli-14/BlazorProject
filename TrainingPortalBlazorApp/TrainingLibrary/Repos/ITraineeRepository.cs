using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repos
{
    public interface ITraineeRepository
    {
        Task AddTraineeAsync(Trainee trainee);
        Task UpdateTraineeAsync(string trainingid, string empid, string status);
        Task DeleteTraineeAsync(string trainingId, string empId);
        Task InsertEmployee(Employee employee);
        Task<Trainee> GetTraineeAsync(string trainingId, string empId);
        Task<List<Trainee>> GetAllTraineesAsync();
        Task<List<Trainee>> GetTraineesByStatusAsync(string status);
        Task<List<Trainee>> GetTraineesByEmpIdAsync(string empId);
        Task<List<Trainee>> GetTraineesByTrainingIdAsync(string trainingId);
    }
}
