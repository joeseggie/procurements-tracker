
using System;
using System.Collections.Generic;

namespace ProcurementTracker
{
    public static class ApplicationConfigurationData
    {
        public static List<(string action, string area, string description)> GetApplicationActions()
        {
            List<(string action, string area, string description)> actions = new()
            {
                ("add_procurement", "PROCUREMENTS", "Add Procurement"),
                ("view_procurement_details", "PROCUREMENTS", "View procurement details"),
                ("edit_procurement", "PROCUREMENTS", "Edit or update procurement details"),
                ("abandon_procurement", "PROCUREMENTS", "Abandon and active or running procurement"),
                ("list_procurements", "PROCUREMENTS", "List all procurements"),
                ("list_unabandoned_procurements", "PROCUREMENTS", "List procurements that have not been abandoned"),
                ("list_abandoned_procurements", "PROCUREMENTS", "List procurements that have been abandoned"),
                ("view_bid", "BIDS", "View bid details"),
                ("add_bid", "BIDS", "Add bid"),
                ("edit_bid", "BIDS", "Edit or update bid details"),
                ("reject_bid", "BIDS", "Reject bid"),
                ("accept_bid", "BIDS", "Accept bid"),
                ("list_bids", "BIDS", "List bids"),
                ("add_supplier", "SUPPLIERS", "Add supplier"),
                ("edit_supplier", "SUPPLIERS", "Edit or update supplier details"),
                ("list_suppliers", "SUPPLIERS", "List suppliers"),
                ("add_user", "USERS", "Add user"),
                ("view_user", "USERS", "View user profile"),
                ("edit_user", "USERS", "Edit or update user profile"),
                ("disable_user", "USERS", "Disable user profile"),
                ("list_users", "USERS", "List user profiles"),
                ("add_role", "ROLES", "Add role"),
                ("edit_role", "ROLES", "Edit role"),
                ("view_role", "ROLES", "View role details"),
                ("list_roles", "ROLES", "List roles"),
                ("view_action", "ACTIONS", "View action"),
                ("list_actions", "ACTIONS", "List actions")
            };

            return actions;
        }

        public static (string? username, string? email, string? password, string? firstname, string? lastname) GetAdminCredentials()
        {
            string? username = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_USERNAME");
            string? email = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_EMAIL");
            string? password = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_PASSWORD");
            string? firstname = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_FIRSTNAME");
            string? lastname = Environment.GetEnvironmentVariable("PROCUREMENT_TRACKER_ADMIN_LASTNAME");

            return (username, email, password, firstname, lastname);
        }
    }
}