using ProcurementTracker.Data;

using System;
using System.Threading.Tasks;

namespace ProcurementTracker.Models.Managers
{
    /// <summary>
    /// Manages operations to add, edit and query assignment of officers to procurements.
    /// </summary>
    public class ProcurementOfficerAssignmentManager : IProcurementOfficerAssignmentManager
    {
        private readonly ProcurementTrackerContext context;

        /// <summary>
        /// Initializes <see cref="ProcurementOfficerAssignment"/>
        /// </summary>
        /// <param name="context">Database context.</param>
        public ProcurementOfficerAssignmentManager(ProcurementTrackerContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<ProcurementOfficerAssignment?> GetProcurementOfficerAssignmentsAsync(Guid id)
        {
            if (context.ProcurementOfficerAssignments is null)
            {
                return null;
            }

            return await context.ProcurementOfficerAssignments.FindAsync(id);
        }
    }
}
