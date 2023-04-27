﻿using AutoMapper;
using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Application.UseCases.Games.UpdateImages;
using MyGuides.Domain.Entities.Games.Commands.AddGame;
using MyGuides.Domain.Entities.Games.Requests;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;
using MyGuides.Utils;
using Steam.Api.Clients.StoreApi;
using Steam.Api.Clients.WebApi;
using Achievement = MyGuides.Domain.Entities.Achievements.Achievement;
using Game = MyGuides.Domain.Entities.Games.Game;

namespace MyGuides.Application.UseCases.Games.AddGame
{
    public class AddGameFromSteamStoreUseCase : TransactionalUseCase<AddGameRequest, GameResult>, IAddGameFromSteamStoreUseCase
    {
        private readonly IMapper _mapper;
        private readonly ISteamWebApiClient _steamApi;
        private readonly ISteamStoreApiWebClient _steamStoreApi;

        public AddGameFromSteamStoreUseCase(
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork unitOfWork,
            ISteamWebApiClient steamApi,
            ISteamStoreApiWebClient steamStoreApi,
            INotificationService notificationService)
            : base(mediator, unitOfWork, notificationService)
        {
            _mapper = mapper;
            _steamApi = steamApi;
            _steamStoreApi = steamStoreApi;
        }

        protected override async Task<GameResult> OnExecuteAsync(AddGameRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.StoreId is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                request.StoreId = AppIdConverter.GetAppId(request.StoreId);

                var result = await _steamApi.GetSchemaForGameAsync("AF458C11CC9AAF3E010199B1E61849DE", request.StoreId);
                var storeResult = await _steamStoreApi.GetAppDetailsFromStore(request.StoreId);

                if (result is null)
                {
                    _notificationService.AddNotification("cadastrar");
                    return default;
                }

                result.Game.AppId = request.StoreId;


                var command = new AddGameCommand(
                    result.Game.GameName,
                    result.Game.GameVersion, 
                    result.Game.AppId, 
                    result.Game.AvailableGameStats.Achievements, 
                    storeResult.HeaderImage, 
                    storeResult.BackgroundRaw);

                return await _mediator.Send(command, cancellationToken);
            }
            catch (Exception ex)
            {
                _notificationService.AddNotification(ex);
                return default;
            }
        }
    }
}
