using System;

namespace visavault_g43.BLL
{
    // Audit is controlled by the DBMS (triggers/stored-procedures).
    // Provide a no-op application wrapper so service calls compile and do not duplicate DB-managed audit rows.
    public static class AuditService
    {
        public static void Log(string entity, int entityId, string fieldName, string oldValue, string newValue, string action, int userId)
        {
            // Intentionally left blank: audit entries are recorded by the database (triggers or stored procedures).
            // If you later want to call a stored procedure from the app, implement it here.
        }
    }
}
