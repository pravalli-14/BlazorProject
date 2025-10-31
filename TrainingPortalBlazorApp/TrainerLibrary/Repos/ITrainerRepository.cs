using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainerLibrary.Models;

namespace TrainerLibrary.Repos
{
    public interface ITrainerRepository
    {
        Task NewTrainerAsync(Trainer trainer);
        Task UpdateTrainerAsync(string trainerId, Trainer trainer);
        Task DeleteTrainerAsync(string trainerId);
        Task<Trainer> GetTrainerAsync(string trainerId);
        Task<List<Trainer>> GetTrainerByTypeAsync(string type);
        Task<List<Trainer>> GetAllTrainersAsync();
    }
}
