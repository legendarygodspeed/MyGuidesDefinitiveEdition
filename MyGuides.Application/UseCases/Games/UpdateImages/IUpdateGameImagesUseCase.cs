﻿using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Games.UpdateImages
{
    public interface IUpdateGameImagesUseCase : INotifiableUseCase<UpdateImagesRequest, GameResult>
    {
    }
}
