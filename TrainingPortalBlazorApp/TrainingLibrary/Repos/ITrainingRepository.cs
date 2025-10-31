using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repos
{
    public interface ITrainingRepository
    {
        Task AddTrainingAsync(Training training);
        Task UpdateTrainingAsync(string trainingId, Training training);
        Task DeleteTrainingAsync(string trainingId);
        Task InsertTrainerAsync(Trainer trainer);
        Task InsertTechnologyAsync(Technology technology);
        Task<Training> GetTrainingAsync(string trainingId);
        Task<List<Training>> GetAllTrainingsAsync();
        Task<List<Training>> GetTrainingByTrainerIdAsync(string trainerId);
        Task<List<Training>> GetTrainingByTechnologyIdAsync(string technologyid);
    }
}
