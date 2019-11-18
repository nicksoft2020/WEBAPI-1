namespace WebApi.JWT
{
    /// <summary>
    /// This class has properties which 
    /// gives access to configure file.
    /// </summary>
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; } // The secret for token.
        public string Client_Url { get; set; } 
    }
}
