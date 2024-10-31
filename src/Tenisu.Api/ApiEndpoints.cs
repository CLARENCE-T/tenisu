namespace Tenisu.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";
    
    public static class Players
    {
        private const string Base = $"{ApiBase}/players";

        public const string GetAll = Base;
        public const string Get = $"{Base}/{{id:int}}";

    }
    
    public static class Statistics
    {
        private const string Base = $"{ApiBase}/statistics";

        public const string GetMixedStatistics = $"{Base}/mixed-statistics";
    }
}