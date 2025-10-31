using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingLibrary.Models;

namespace TrainingLibrary.Repos
{
    public class EFTrainingRepository : ITrainingRepository
    {
        ZelisTrainingEFDBContext ctx;
        public EFTrainingRepository()
        {
            ctx = new ZelisTrainingEFDBContext();
        }
        public async Task AddTrainingAsync(Training training)
        {
            try
            {
                await ctx.Trainings.AddAsync(training);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task DeleteTrainingAsync(string trainingId)
        {
            try
            {
                Training training = await GetTrainingAsync(trainingId);
                ctx.Trainings.Remove(training);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task<List<Training>> GetAllTrainingsAsync()
        {
            List<Training> trainings = await (from t in ctx.Trainings select t).ToListAsync();
            return trainings;
        }

        public async Task<Training> GetTrainingAsync(string trainingId)
        {
            try
            {
                Training training = await (from t in ctx.Trainings where t.TrainingId == trainingId select t).FirstAsync();
                return training;
            }
            catch (Exception ex)
            {
                throw new TrainingException("No such Training Id");
            }
        }

        public async Task<List<Training>> GetTrainingByTechnologyIdAsync(string technologyid)
        {
            List<Training> trainings = await (from t in ctx.Trainings where t.TechnologyId == technologyid select t).ToListAsync();
            if (trainings.Count == 0)
                throw new TrainingException("No such Trainings of given technology Id");
            else
                return trainings;
        }

        public async Task<List<Training>> GetTrainingByTrainerIdAsync(string trainerId)
        {
            List<Training> trainings = await (from t in ctx.Trainings where t.TrainerId == trainerId select t).ToListAsync();
            if (trainings.Count == 0)
                throw new TrainingException("No such Trainings of given trainer Id");
            else
                return trainings;
        }

        public async Task InsertTechnologyAsync(Technology technology)
        {
            try
            {
                await ctx.Technologies.AddAsync(technology);
                await ctx.SaveChangesAsync();
            }
            catch (TrainingException ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task InsertTrainerAsync(Trainer trainer)
        {
            try
            {
                await ctx.Trainers.AddAsync(trainer);
                await ctx.SaveChangesAsync();
            }
            catch (TrainingException ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

        public async Task UpdateTrainingAsync(string trainingId, Training training)
        {
            try
            {
                Training training2edit = await GetTrainingAsync(trainingId);
                training2edit.TrainerId = training.TrainerId;
                training2edit.TechnologyId = training.TechnologyId;
                training2edit.StartDate = training.StartDate;
                training2edit.EndDate = training.EndDate;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new TrainingException(ex.Message);
            }
        }

    }
}
