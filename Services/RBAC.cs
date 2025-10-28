namespace SafeVault.Services {
    public static class RBAC {
        public static bool IsAuthorized(string userRole, string requiredRole) {
            return userRole == requiredRole;
        }
    }
}