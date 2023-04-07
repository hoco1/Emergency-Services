namespace EmergencyServices
{
    class FirefightersCommand : ICommand
{
    private EmergencyService _emergencyService;
    
    public FirefightersCommand(EmergencyService emergencyService)
    {
        _emergencyService = emergencyService;
    }
    
    public void Execute()
    {
        _emergencyService.SendMessage();
    }
}
}