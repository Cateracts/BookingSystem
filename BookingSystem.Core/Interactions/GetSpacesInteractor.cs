using BookingSystem.Core.Interfaces;
using System;

namespace BookingSystem.Core.Interactions
{
    /// <summary>
    /// An interactor for getting spaces
    /// </summary>
    public class GetSpacesInteractor : IGetSpacesRequest
    {
        private readonly IGetSpacesResponseHandler responseHandler;

        private readonly ISpaceRepository spaceRepository;

        /// <summary>
        /// Creates an interaction that will retrieve spaces
        /// </summary>
        /// <param name="responseHandler">The entity responsible for handling the response from the interactor</param>
        /// <param name="spacesRepository">Repository to search for spaces</param>
        public GetSpacesInteractor(IGetSpacesResponseHandler responseHandler, ISpaceRepository spaceRepository)
        {
            this.responseHandler = responseHandler;
            this.spaceRepository = spaceRepository;
        }

        /// <summary>
        /// Executes the interactor
        /// </summary>
        public void Execute()
        {
            try
            {
                responseHandler.Spaces = spaceRepository.Get();
                responseHandler.Success();
            }
            catch(Exception e)
            {
                responseHandler.Error(e);
            }
        }
    }
}
