using BookingSystem.Core.Entities;
using System.Collections.Generic;

namespace BookingSystem.Core.Interfaces
{
    /// <summary>
    /// A contract that any response handler  for getting spaces must implement
    /// </summary>
    public interface IGetSpacesResponseHandler : IResponseHandler
    {
        IList<Space> Spaces { get; set; }
    }
}
