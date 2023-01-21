using System;
using System.Threading.Tasks;

namespace ProcurementTracker.Models.Managers
{
    /// <summary>
    /// Interface to manage operations to add, edit and query for assignments of officers to procurements.
    /// </summary>
    public interface IProcurementOfficerAssignmentManager
    {
        /// <summary>
        /// Get the procurement officer assignment by id.
        /// </summary>
        /// <param name="id">Id of the procurement officer assyment.</param>
        /// <returns>Procurement officer assignment.</returns>
        Task<ProcurementOfficerAssignment?> GetProcurementOfficerAssignmentsAsync(Guid id);
    }
}