using System;

namespace teste
{
    // Ajout d'une définition minimale pour PortTestResult afin de corriger l'erreur CS0246.
    internal class PortTestResult
    {
        // Ajoutez ici les membres nécessaires selon vos besoins.
    }

    internal class PortTestEntry : PortTestResult
    {
        public DateTime Timestamp { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string Endpoint { get; set; }
        public bool Success { get; set; }
        public int HttpCode { get; set; }
        public string HttpStatus { get; set; }
        public double ResponseTimeMs { get; set; }
        public string Error { get; set; }
    }
}